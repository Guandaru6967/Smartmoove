using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using Smartmoveapp.Views.Popups;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views.Document
{
          [XamlCompilation(XamlCompilationOptions.Compile)]
          public partial class DocumentEditingPage : ContentPage
          {
                    public DocumentEditingPage(List<ImageObject> images,ref Folder  folder,bool  isSinglePhoto)
                    {
                              InitializeComponent();
                              BindingContext =new DocumentEditingViewModel { CurrentImage=images.First(),Folder=folder,IsSinglePhoto=isSinglePhoto,Images=images};
                              
                    }
                    private async void ScanDocument(object sender,EventArgs e) 
                    {
                              var viewModel= BindingContext as DocumentEditingViewModel;

                              var folder=await this.ShowPopupAsync(new DocumentScanFeedbackPopup(viewModel.CurrentImage, viewModel.Folder));
                              viewModel.Folder = folder as Folder;
                             // await Shell.Current.GoToAsync("HomePage",viewModel.folder);
                              
                    }
                   
                    public void CurrentImageSelected(object sender, SelectionChangedEventArgs e) 
                    {
                              var listing=e.CurrentSelection as List<object>;
                              var selecteditem = listing.LastOrDefault() as ImageObject;
                              Debug.WriteLine("Selection Not Null, {0}",selecteditem != null);
                              var viewModel=BindingContext as DocumentEditingViewModel;
                              if (selecteditem!=null) 
                              {
                                        viewModel.CurrentImage = selecteditem;
                              }
                    }
                    private async void CropAction(object sender,EventArgs e) 
                    {
                              var viewModel = BindingContext as DocumentEditingViewModel;

                             await  Navigation.PushAsync(new CroppingPage(viewModel.CurrentImage));
                    }

                   
          }
}