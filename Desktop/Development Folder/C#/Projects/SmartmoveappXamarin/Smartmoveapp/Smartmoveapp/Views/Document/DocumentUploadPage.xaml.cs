using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using Smartmoveapp.Views.Popups;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views.Document
{
          [XamlCompilation(XamlCompilationOptions.Compile)]
          public partial class DocumentUploadPage : ContentPage
          {
                    System.Timers.Timer timer = new System.Timers.Timer(1000);
                    public DocumentUploadPage(ImageObject image,Folder folder)
                    {
                              InitializeComponent();
                              DateTime startTime = DateTime.Now;
                              
                              timer.Elapsed += async (timerObject, e) =>
                              {
                                        if (e.SignalTime - startTime >= TimeSpan.FromSeconds(10))
                                        {
                                                  Debug.WriteLine("Time , {0}", e.SignalTime);
                                                  await Device.InvokeOnMainThreadAsync(async () =>
                                                  {

                                                            var response= await this.ShowPopupAsync(new DocumentScanFeedbackPopup(image,folder));
                                                            var action = (bool)response;
                                                            if (action) 
                                                            {
                                                            }
                                                            else 
                                                            {
                                                            }
                                                 
                                                     
                                                            await this.Navigation.PushAsync(new MainPage());
                                                          
                                                  });
                                                  timer.Stop();
                                                  timer.Dispose();
                                        }

                              };
                    }
                    protected override void OnAppearing()
                    {
                              base.OnAppearing();

                            
                        
                              timer.Start();
          } 
          }
}