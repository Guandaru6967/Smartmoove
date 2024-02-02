using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views.Folders
{
          [XamlCompilation(XamlCompilationOptions.Compile)]
          public partial class FilterFolderPopup : Popup
    {
                    public FilterFolderPopup(ref List<Folder> folders)
                    {
                              InitializeComponent();
                              BindingContext = new FolderFilterViewModel() { Folders = folders };
                    }
                    private void CloseFilters(object sender,EventArgs e)   
                    {
                              var viewModel = BindingContext as FolderFilterViewModel;
                              var listing = viewModel.Folders.ToList();
                              var filtered = new List<Folder>();
                               filtered.AddRange(listing.Where((x) => viewModel.DocPanelSwitch.InvoiceActive?x.Documents.Select(x => x.DocType).Contains("INVOICE"):viewModel.DocPanelSwitch.InformationActive? x.Documents.Select(x => x.DocType).Contains("INFO") :viewModel.DocPanelSwitch.ContractActive?x.Documents.Select(x => x.DocType).Contains("CONTRACT"):false).ToList());
                            
                              
                       
                              if (viewModel.FavouriteActive)
                              {

                                        filtered= filtered.Where((x) => x.IsFavourite).ToList();
                              }
                              if (viewModel.AgentActive)
                              {
                                         filtered= filtered.Where((x) => x.Documents.Select(doc => doc.AgentId).Any()).ToList();

                              }
                              this.Dismiss(filtered);
                    }
                  

          }
}