using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views.Popups
{
          [XamlCompilation(XamlCompilationOptions.Compile)]
          public partial class SortDocumentPopup : Popup
          {
                    public SortDocumentPopup(List<SmartDocument> documents)
                    {
                              InitializeComponent();
                              BindingContext = new SortDocumentsViewModel { Documents = documents };
                    }
                    private void SortDocuments(object sender,EventArgs e) 
                    {
                              var viewModel=BindingContext as SortDocumentsViewModel;
                              this.Dismiss(viewModel.SortedDocuments);

                    }
                    private void NameCheckedChanged(object sender, CheckedChangedEventArgs e)
                    {
                              var viewModel = BindingContext as SortDocumentsViewModel;
                              if (e.Value)
                              {

                                      viewModel.Date = !e.Value;
                              }
                    }
                    private void DateCheckedChanged(object sender, CheckedChangedEventArgs e)
                    {
                              var viewModel = BindingContext as SortDocumentsViewModel;
                              if (e.Value)
                              {
                                         viewModel.Name = !e.Value;
                              }
                    }
          }
}