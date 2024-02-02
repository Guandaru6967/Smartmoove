
using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using Smartmoveapp.Views.Document;
using Smartmoveapp.Views.Popups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Smartmoveapp.Views
{
    public interface IPdfView
    {
        event EventHandler DeleteFile;
    }
    public partial class PDFView : WebView
    {
        public static BindableProperty DocSourceProperty = BindableProperty.Create(nameof(DocSource), typeof(string), typeof(WebView), string.Empty);
        public string DocSource { get => (string)GetValue(DocSourceProperty); set => SetValue(DocSourceProperty, value); }
        public PDFView() 
        {
            DocSource = string.Empty;

        }
        public PDFView(string file) 
        {
            DocSource = file;
            Source = DocSource;
        }
       public void SetFile(string source) 
        {
            DocSource = source;
            Source= DocSource;
        }
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FolderPage : ContentPage
    {
          public FolderPage()
        {
            
            InitializeComponent();
            //Menu Button In Center of Page
        }
          Folder SelectedFolder;
          public FolderPage(Folder folder)
        {

            InitializeComponent();

                             BindingContext=new FolderPageViewModel() { IsGridView= true ,Folder=folder};
     
        }
          public void OnSelect(object sender, SelectionChangedEventArgs args)
          {
                    //Console.WriteLine(1000);
                    if (args.CurrentSelection.Any())
                    {
                              Console.WriteLine("****Document Selection {0}", args.CurrentSelection);
                              var Document = args.CurrentSelection.FirstOrDefault() as SmartDocument;
                              Page Page= null;
                              Debug.WriteLine(Document.DocType);
                              switch (Document.DocType) 
                              {
                              case "INVOICE":
                                        Page = new InvoiceDetailPage(Document);  
                                        break;
                              case "INFO":
                                        Page = new InfoDetailPage(Document);
                                        break;
                              case "CONTRACT":
                                        Page =new ContractDetailPage(Document,SelectedFolder);
                                        break;
                              default:
                                        break;

          }
                                        var documentView = sender as CollectionView;
                                        documentView.SelectedItem = null;
                                        documentView.SelectedItems.Clear();


                                        Navigation.PushAsync((Page)Page,true);
          }
          }
                    private void DocumentPage(object sender, EventArgs e)
                    {
                              var viewModel = BindingContext as FolderPageViewModel;
                              var folder = viewModel.Folder;
                              this.Navigation.PushAsync(new ScanningPage(ref folder));
                    }

                    public void SortListViewByName(object sender, EventArgs args)
                    {
                              var viewmodel = BindingContext as FolderPageViewModel;
                              viewmodel.FolderDocuments = new ObservableCollection<SmartDocument>(viewmodel.Folder.Documents.OrderBy(a => a.Name).ToList());

                       

          }
               
                    private async void SortAction(object sender,EventArgs e) 
                    {
                              var viewModel= BindingContext as FolderPageViewModel;
                              var response=await this.ShowPopupAsync(new SortDocumentPopup(viewModel.Folder.Documents));
                              if(response != null) 
                              {
                                        viewModel.FolderDocuments =new ObservableCollection<SmartDocument>( response as List<SmartDocument>);
                              }

                    }
                    private  async void AddDocument(object sender,EventArgs e) 
                    {

                              var viewModel = BindingContext as FolderPageViewModel;
                              var response =await  this.ShowPopupAsync(new DocumentAddPopup());
                              var folder = viewModel.Folder;
                              if (!(bool)response) 
                              {
                                       var file= await MediaPicker.PickPhotoAsync(new MediaPickerOptions { Title = "Scan Document" });
                                        using (MemoryStream memstream = new MemoryStream()) 
                                        {
                                                  var stream=await file.OpenReadAsync();
                                                  stream.CopyTo(memstream);
                                                  ImageObject image = new ImageObject { ImageData =memstream.ToArray(), TimeTaken = DateTime.Now };
                                                 await  this.Navigation.PushAsync(new DocumentEditingPage(new List<ImageObject> { image }, ref folder, true));
                                        }                             
                              }
                              else {
                                        await this.Navigation.PushAsync(new ScanningPage(ref folder));
                              }

                     }
                    public void ToggleSearch(object sender ,EventArgs e) 
                    {
                              var viewModel=BindingContext as FolderPageViewModel;
                              viewModel.IsSearch = !viewModel.IsSearch;
                              
                    }
          public void SortListViewByDate(object sender, EventArgs args)
          {
                              var viewmodel = BindingContext as FolderPageViewModel;

                              if (viewmodel.IsGridView)
                              {
                                        viewmodel.FolderDocuments = new ObservableCollection<SmartDocument>(viewmodel.Folder.Documents.OrderBy(a => a.Created_Dt.ToUniversalTime()).ToList());
                              }
                              else { viewmodel.FolderDocuments = new ObservableCollection<SmartDocument>( viewmodel.Folder.Documents.OrderBy(a => a.Created_Dt.ToUniversalTime()).ToList()); }
          }
          private void Entry_TextChanged(object sender, TextChangedEventArgs e)
          {
                              string text = FilterEntry.Text;
                              var viewmodel = BindingContext as FolderPageViewModel;
                              viewmodel.FolderDocuments = new ObservableCollection<SmartDocument>(viewmodel.Folder.Documents.Where(x => x.Name.Contains(text) || x.Name.ToLower().Contains(text.ToLower())));
                         
                    
          }
          private void ToggleDocumentView(object sender, EventArgs e)
          {
                    var viewmodel = BindingContext as FolderPageViewModel;
                    viewmodel.IsGridView = !viewmodel.IsGridView;
          }
    }
}