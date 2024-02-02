using Smartmoveapp.Models;
using Smartmoveapp.Utilities;
using Smartmoveapp.ViewModels;
using Smartmoveapp.Views.Popups;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views.Document
{
          [XamlCompilation(XamlCompilationOptions.Compile)]
          public partial class ScanningPage : ContentPage
          {
                    public ScanningPage(ref Folder folder)
                    {
                              InitializeComponent();
                              BindingContext = new ScanningPageViewModel() { Folder=folder};
                              CameraViewPanel.VideoStabilization = false;
                              CameraViewPanel.CameraOptions = Xamarin.CommunityToolkit.UI.Views.CameraOptions.Back;
                              CameraViewPanel.Zoom = 1;
                    }

                    private async void CameraMediaCaptured(object sender, Xamarin.CommunityToolkit.UI.Views.MediaCapturedEventArgs e)
                    {

                              var imagedata = e.ImageData;
                              // CameraViewPanel.Shutter();
                              var viewModel = BindingContext as ScanningPageViewModel;

                              Debug.WriteLine("Image Taken");
                              Debug.WriteLine(e.Rotation);
                              ImageRotationExtenstion rotationExtenstion = new ImageRotationExtenstion(imagedata, Convert.ToSingle(e.Rotation));
                              
                              if (rotationExtenstion.IsRotated)
                              {
                                        viewModel.Images.Add(new ImageObject { ImageData = rotationExtenstion.Data, TimeTaken = DateTime.Now, Id = Guid.NewGuid().ToString() });
                              
                                          //       File.WriteAllBytes("rotationtest.png", rotationExtenstion.Data);
                                        
                                        await this.DisplayToastAsync("Image Taken");
                                        var folder = viewModel.Folder;

                                        if (viewModel.IsSinglePhoto)
                                        {
                                                  await this.Navigation.PushAsync(new DocumentEditingPage(viewModel.Images, ref folder, viewModel.IsSinglePhoto));
                                        }
                                        else

                                        {
                                                  Debug.WriteLine("Made things happen");
                                                  var image = viewModel.Images.LastOrDefault();
                                                  if (image is not null)
                                                  {
                                                            Debug.WriteLine("Showing Image");
                                                            var accept = await this.ShowPopupAsync(new ImageViewPopup(image) { });
                                                            Debug.WriteLine("IMage Shown : {0} bytes", image.ImageData.Length);
                                                            if (accept is false)
                                                            {
                                                                      viewModel.Images.Remove(image);
                                                            }
                                                  }
                                        }
                              }
                    }
                   
                    private  void TakePhoto(object sender,EventArgs e) 
                    {
                              //new Random().Next(0, Convert.ToInt32(CameraViewPanel.MaxZoom));
                              Debug.WriteLine(CameraViewPanel.Zoom);
                              Debug.WriteLine(CameraViewPanel.MaxZoom);
                              Debug.WriteLine(CameraViewPanel.IsAvailable);
                    
                             
                              if (CameraViewPanel.IsAvailable)
                              {
                                        CameraViewPanel.Shutter();
                                   
                                        
                              }
                    }
                    private async void DoneTakingBatchPhoto(object sender ,EventArgs e)
                    {
                              var viewModel = BindingContext as ScanningPageViewModel;
                              var folder = viewModel.Folder;
                              if (viewModel.Images.Any())
                              {
                                        await this.Navigation.PushAsync(new DocumentEditingPage(viewModel.Images, ref folder, viewModel.IsSinglePhoto));
                              }
                              else 
                              {
                                        await this.DisplayToastAsync("No photos have been taken.");
                              }
                    }
                    private void ImageTabSelectionChanged(object sender, Xamarin.CommunityToolkit.UI.Views.TabSelectionChangedEventArgs e)
                    {

                              var viewModel = BindingContext as ScanningPageViewModel;
                              viewModel.IsSinglePhoto=e.NewPosition==0 ;
                              Debug.WriteLine(" Tab Selection {0}",e.NewPosition);
                              viewModel.Images.Clear();
                    }
          }
}