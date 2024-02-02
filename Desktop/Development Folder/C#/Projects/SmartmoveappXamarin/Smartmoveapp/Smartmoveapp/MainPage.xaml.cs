
using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using Smartmoveapp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.PlatformConfiguration;
using Smartmoveapp.Controls;
using Smartmoveapp.Views.Popups;
using Smartmoveapp.Views.Agent;
using Smartmoveapp.Views.Folders;
using System.Collections.ObjectModel;
using Smartmoveapp.Views.Document;
using FFImageLoading.Forms;
namespace Smartmoveapp
{
    public partial class ServiceContent : ContentView
    {
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(IconButton), ImageSource.FromResource("Smartmoveapp.Assets.BackgroundTest3.jpg", Application.Current.GetType().Assembly));
        public ImageSource ImageSource
        { get => (ImageSource)GetValue(ImageSourceProperty); set => SetValue(ImageSourceProperty, value); }
    }


      
          public class FolderListView : ContentView 
    {
        public IEnumerable<object> ItemSource { get=>(IEnumerable<object>)GetValue(ItemSourceProperty); set=>SetValue(ItemSourceProperty,value); }
        public void Refresh(IEnumerable<object> List ) 
        {
            ItemSource = List;
        }
        public static BindableProperty ItemSourceProperty =BindableProperty.Create(nameof(ItemSource),typeof(IEnumerable<object>),typeof(FolderListView));
    }
          public partial class MainPage : ContentPage
          {
                    public bool IsSortViewOpen = false;
                    public MainPage()
                    {
                              InitializeComponent();
                    }
                    public MainPage(object Model)
                    {
                              InitializeComponent();

                    }



                    private void OnMapClicked(object sender, MapClickedEventArgs e)
                    {
                              var page = new MapPage(new Position(e.Position.Latitude, e.Position.Longitude));
                              Navigation.PushAsync(page, true);
                    }

                    private async void FolderView_SelectionChanged(object sender, SelectionChangedEventArgs e)
                    {
                              if (e.CurrentSelection.Any())
                              {
                                        Console.WriteLine("**** Selection {0}", e.CurrentSelection);
                                        Console.WriteLine(100);
                                        var FolderInfo = e.CurrentSelection.FirstOrDefault() as Folder;
                                        Console.WriteLine(300);
                                        var page = new FolderPage(FolderInfo);
                                        Console.WriteLine(400);
                                        var foldersViews = sender as CollectionView;
                                        foldersViews.SelectedItem = null;
                                        foldersViews.SelectedItems.Clear();
                                        if (FolderInfo.LockCode != string.Empty)
                                        {
                                                  var result = await this.ShowPopupAsync(new FolderCodePrompt(FolderInfo.LockCode));
                                                  if (result is null)
                                                  {
                                                            return;
                                                  }
                                                  else if ((bool)result == true)
                                                  {
                                                            await Navigation.PushAsync(page, true);
                                                            return;
                                                  }
                                                  else
                                                  {

                                                            this.DisplayToastAsync("Invalid folder passcode!");
                                                            return;
                                                  }
                                        }
                                        await Navigation.PushAsync(page, true);

                              }
                    }
                    private void PassCodePrompt(object sender, EventArgs args)
                    {
                              this.ShowPopup(new PasswordPrompt(""));
                    }
                    private void RefreshView_Refreshing(object sender, EventArgs e)
                    {

                              // Folders.ItemsSource = HomeViewModel.Folders;
                              var refreshview = sender as RefreshView;
                              refreshview.IsRefreshing = false;
                    }
                    private void FolderSerachEntryTextChanged(object sender, TextChangedEventArgs e)
                    {
                              string text = FilterEntry.Text;
                              var viewmodel = BindingContext as HomeViewModel;
                              viewmodel.FolderListing= viewmodel.Folders.Where((x) => x.FolderName.Contains(text) || x.FolderName.ToLower().Contains(text.ToLower())).ToList();
                              
                    }
                    private async void OnEnterFolderPage(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
                    {
                              var passcode = await SecureStorage.GetAsync("passcode");
                              if (passcode != null && passcode != string.Empty)
                              {
                                        this.ShowPopup(new PasswordPrompt(passcode));
                              }
                    }
                    private void Button_Clicked(object sender, EventArgs e)
                    {

                    }
                    public void ToggleSearch(object sender, EventArgs e)
                    {
                              var viewModel = BindingContext as HomeViewModel;
                              viewModel.SearchActive = !viewModel.SearchActive;

                    }
                    public void ToggleFolderView(object sender, EventArgs e)
                    {
                              var viewModel = BindingContext as HomeViewModel;
                              viewModel.IsFolderView = !viewModel.IsFolderView;
                    }
              
                    public async  void FolderOptions(object sender, EventArgs e)
                    {
                              var button = sender as ImageButton;
                              var viewModel = button.BindingContext as Folder;
                              var mainViewModel = BindingContext as HomeViewModel;
                              if (!mainViewModel.FolderOptionsOpen)
                              {
                                        mainViewModel.FolderOptionsOpen = true;
                                        var folders = mainViewModel.Folders;
                                        await this.ShowPopupAsync(new FolderOptions(ref folders, ref viewModel));
                                  
                                        mainViewModel.FolderListing = mainViewModel.Folders.ToList();
                                        mainViewModel.FolderOptionsOpen = false;
                              }

                    }
                    private async void AddFolder(object sender, EventArgs args)
                    {
                              var viewmodel = (HomeViewModel)BindingContext;
                              var data = viewmodel.Folders;
                              var addauto =await  this.ShowPopupAsync(new FolderAddPopup());
                              if(addauto is null) 
                              {
                                        return;
                              }
                              var isaddauto = (bool)(addauto);
                              if (!isaddauto)
                              {
                                        var folder = new Folder { Created_Dt = DateTime.Now, Documents = new List<SmartDocument> { }, Modified_Dt = DateTime.Now };
                                        await Navigation.PushAsync(new ScanningPage(ref folder));

                              }
                              else
                              {
                                        var folders = await this.ShowPopupAsync(new CreateFolder(data)) as List<Folder>;
                                        viewmodel.Folders = folders.ToList();
                                        viewmodel.FolderListing = folders.ToList();
                              }
                              
                    }
                    private async void SortFolders(object sender, EventArgs args) 
                    {
                            var viewModel = (HomeViewModel)BindingContext;
                              if (!IsSortViewOpen)
                              {
                                        IsSortViewOpen = true;
                                        var response = await this.ShowPopupAsync(new SortFolderPopup(viewModel.FolderListing.ToList()));
                                        viewModel.FolderListing = response as List<Folder>;
                                        IsSortViewOpen =false;
                              }
                            
                    }
                    private async void ToggleFolderPanel(object sender, EventArgs e)
                    {
                              var viewmodel = (HomeViewModel)BindingContext;
                              var data = viewmodel.Folders;
                             var listing= await this.ShowPopupAsync(new FilterFolderPopup(ref data));
                              if(listing is not null) 
                              {
                                        viewmodel.FolderListing = listing as List<Folder>;
                              }
                    }
                    
                    private void AgentSelected(object sender, SelectionChangedEventArgs e)
                    {
                              var agent = e.CurrentSelection.FirstOrDefault() as Agency;
                              var viewModel = BindingContext as HomeViewModel;
                              var listing = viewModel.Folders.Select(x => x.Documents.Where(doc => doc.AgentId == agent.Id));
                              var doclist = new List<SmartDocument>();
                              foreach (var documentarray in listing)
                              {
                                        doclist.AddRange(documentarray.AsEnumerable());
                              }
                              Navigation.PushAsync(new AgentPage(agent, doclist));
                              var agentcollection = sender as CollectionView;
                              agentcollection.SelectedItems.Clear();
                              agentcollection.SelectedItem = null;

                    }

                    private async void AddAgentPage(object sender, EventArgs e)
                    {

                              /* Fetch All the Users */
                              var listing = new List<Agency>()
                              {
                                        new Agency{Id=124234,Name="Game Limited",Rating=2.4,Position=new Tuple<double,double>(1.2,3.4),Ratingcount=2,Address="Games"},
                                        new Agency{Id=21234124,Name="Pool Vision ",Address="News Limited",Rating=2.4,Position=new (2.3,4.4)},
                                        new Agency
                                                  {
                                                      Id = 4,
                                                      Name = "Sky High Realtors",
                                                      Address = "321 Skyline Drive",
                                                      Rating = 4.0,
                                                      Ratingcount = 110,
                                                      Position = new Tuple<double, double>(33.7490, -84.3880),
                                                      Email = "info@skyhighrealtors.com",
                                                      Tel = "555-2468",
                                                      Phone = "555-1357"
                                                  },

                                        new Agency
                                        {
                                            Id = 5,
                                            Name = "Exotic Travels",
                                            Address = "789 Paradise Road",
                                            Rating = 4.8,
                                            Ratingcount = 150,
                                            Position = new Tuple<double, double>(25.7617, -80.1918),
                                            Email = "travel@exotic.com",
                                            Tel = "555-3690",
                                            Phone = "555-9753"
                                        },

                                        new Agency
                                        {
                                            Id = 6,
                                            Name = "SafeGuard Insurance",
                                            Address = "654 Coverage Lane",
                                            Rating = 4.1,
                                            Ratingcount = 85,
                                            Position = new Tuple<double, double>(37.7749, -122.4194),
                                            Email = "info@safeguardins.com",
                                            Tel = "555-8024",
                                            Phone = "555-1769"
                                        },// Assuming the previous code has been included, add the following to create 10 more instances

                                        new Agency
                                        {
                                            Id = 7,
                                            Name = "Metro Realty Group",
                                            Address = "567 Urban Avenue",
                                            Rating = 4.3,
                                            Ratingcount = 95,
                                            Position = new Tuple<double, double>(40.7128, -74.0060),
                                            Email = "info@metrorealty.com",
                                            Tel = "555-1111",
                                            Phone = "555-2222"
                                        },

                                        new Agency
                                        {
                                            Id = 8,
                                            Name = "Globetrotter Vacations",
                                            Address = "876 Wanderlust Road",
                                            Rating = 4.7,
                                            Ratingcount = 120,
                                            Position = new Tuple<double, double>(34.0522, -118.2437),
                                            Email = "info@globetrotter.com",
                                            Tel = "555-3333",
                                            Phone = "555-4444"
                                        },

                                        new Agency
                                        {
                                            Id = 9,
                                            Name = "Guardian Assurance",
                                            Address = "987 Safety Street",
                                            Rating = 3.9,
                                            Ratingcount = 75,
                                            Position = new Tuple<double, double>(41.8781, -87.6298),
                                            Email = "info@guardianassurance.com",
                                            Tel = "555-5555",
                                            Phone = "555-6666"
                                        },
                                        new Agency
                                        {
                                            Id = 10,
                                            Name = "Summit Properties",
                                            Address = "123 Mountain View Drive",
                                            Rating = 4.5,
                                            Ratingcount = 110,
                                            Position = new Tuple<double, double>(39.7392, -104.9903),
                                            Email = "info@summitproperties.com",
                                            Tel = "555-7777",
                                            Phone = "555-8888"
                                        },

                                        new Agency
                                        {
                                            Id = 11,
                                            Name = "Horizon Holidays",
                                            Address = "456 Sunset Boulevard",
                                            Rating = 4.2,
                                            Ratingcount = 105,
                                            Position = new Tuple<double, double>(33.6846, -117.8265),
                                            Email = "info@horizonholidays.com",
                                            Tel = "555-9999",
                                            Phone = "555-0000"
                                        },

                                        new Agency
                                        {
                                            Id = 12,
                                            Name = "Shield Insure",
                                            Address = "789 Secure Street",
                                            Rating = 4.1,
                                            Ratingcount = 88,
                                            Position = new Tuple<double, double>(37.7749, -122.4194),
                                            Email = "info@shieldinsure.com",
                                            Tel = "555-1212",
                                            Phone = "555-3434"
                                        },

// Add 7 more instances following a similar pattern...


                              };
                              /* Select Agent */

                              var agentselected = await this.ShowPopupAsync(new AddAgentPopup(listing)) as Agency;
                              var viewModel = BindingContext as HomeViewModel;
                              /*Add agent*/
                              viewModel.Agencies.Add(agentselected);


                    }
                    private async void AgentButtonSelected(object sender, EventArgs e)
                    {
                              var button = sender as Button;
                              var buttonModel = button.BindingContext as Agency;
                              var viewModel = BindingContext as HomeViewModel;
                              var listing = viewModel.Folders.Select(x => x.Documents.Where(doc => doc.AgentId == buttonModel.Id));
                              var doclist = new List<SmartDocument>();
                              foreach (var documentarray in listing)
                              {
                                        doclist.AddRange(documentarray.AsEnumerable());
                              }
                             await Navigation.PushAsync(new AgentPage(buttonModel, doclist));
                    }
                    private void OnFavoriteSwipeItemInvoked(object sender, EventArgs e)
                    {
                              var swipeitem = sender as SwipeItem;
                              var mainViewModel = BindingContext as HomeViewModel;

                              var viewModel= swipeitem.BindingContext as Folder;
                              viewModel.IsFavourite = !viewModel.IsFavourite;
                              
                    }
                    
                    private async void OnLockFolderSwipeItemInvoked(object sender, EventArgs e) 
                    {
                              var swipeitem = sender as SwipeItem;
                              var mainViewModel = BindingContext as HomeViewModel;

                              var viewModel = swipeitem.BindingContext as Folder;
                              await this.ShowPopupAsync(new LockFolder(viewModel));

                    }
                    private void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
                    {
                              var swipeitem = sender as SwipeItem;
                              var mainViewModel = BindingContext as HomeViewModel;

                              var viewModel = swipeitem.BindingContext as Folder;
                              mainViewModel.Folders.Remove(viewModel);
                              mainViewModel.FolderListing.Remove(viewModel);
                              mainViewModel.Folders = mainViewModel.Folders.ToList();
                              mainViewModel.FolderListing = mainViewModel.FolderListing.ToList();

                    }

                    private async void ImagesOnFolderSelected(object sender, SelectionChangedEventArgs e)
                    {
                              var listing=e.CurrentSelection as List<object>;
                             var doc= listing.FirstOrDefault() as SmartDocument;
                              var mainmodel=BindingContext as HomeViewModel;

                              var folder=mainmodel.Folders.Where(x => x.Documents.Contains(doc)).FirstOrDefault() ;
                             
                              if (folder.LockCode != string.Empty)
                              {
                                        var result = await this.ShowPopupAsync(new FolderCodePrompt(folder.LockCode));
                                        if (result is null)
                                        {
                                                  return;
                                        }
                                        else if ((bool)result == true)
                                        {
                                                  await Navigation.PushAsync(new FolderPage(folder), true);
                                                  return;
                                        }
                                        else
                                        {

                                                await  this.DisplayToastAsync("Invalid folder passcode!");
                                                  return;
                                        }
                              }
                              //await Navigation.PushAsync(new FolderPage(folder));
        }
    }
}
          
