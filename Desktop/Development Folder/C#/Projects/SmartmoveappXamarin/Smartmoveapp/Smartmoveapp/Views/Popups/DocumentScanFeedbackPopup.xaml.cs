using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views.Popups
{
          [XamlCompilation(XamlCompilationOptions.Compile)]
          public partial class DocumentScanFeedbackPopup : Xamarin.CommunityToolkit.UI.Views.Popup
    {
                    public DocumentScanFeedbackPopup(ImageObject image,Folder folder)
                    {
                              InitializeComponent();
                              DocFeedBackViewModel feedbackViewModel = new DocFeedBackViewModel() {Folder=folder, ImageTaken=image};
                              BindingContext= feedbackViewModel;
                              
                              DateTime startTime = DateTime.Now;
                              System.Timers.Timer timer= new System.Timers.Timer();
                              timer.Elapsed += async (timerObject, e) =>
                              {
                                        if (e.SignalTime - startTime >= TimeSpan.FromSeconds(10))
                                        {
                                                  Debug.WriteLine("Time , {0}", e.SignalTime);
                                                  await Device.InvokeOnMainThreadAsync( () =>
                                                  {


                                                            var viewModel = BindingContext as DocFeedBackViewModel;
                                                            viewModel.IsBusy =false;
                                                        
                                                    

                                                  });
                                                  timer.Stop();
                                                  timer.Dispose();
                                        }

                              };
                              timer.Start();
                    }
                    
                    private void Save(object semder,EventArgs e) 
                    {
                              var viewModel = BindingContext as DocFeedBackViewModel;
                              viewModel.Folder.Documents.Add(viewModel.Document);
                              if (viewModel.Folder.FolderName == string.Empty || viewModel.Folder.FolderName == null)
                              {

                                        viewModel.Folder.FolderName = DateTime.Now.ToString("hh:mm|dd-MM-yyyy");
                              }

                              this.Dismiss(viewModel.Folder);
                    }
          }
}