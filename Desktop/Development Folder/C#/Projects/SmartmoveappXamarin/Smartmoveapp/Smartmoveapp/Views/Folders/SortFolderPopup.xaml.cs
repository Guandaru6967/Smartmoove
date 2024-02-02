using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
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
	public partial class SortFolderPopup : Popup
	{
		public SortFolderPopup (List<Folder> folders)
		{
			InitializeComponent ();
			BindingContext = new SortFolderViewModel() { Folders=folders,Date=false,Name=true,NumberOfDocuments=false};
		}
		private void SortFolders(object sender,EventArgs e) 
		{
			var viewModel=BindingContext as SortFolderViewModel;
			this.Dismiss(viewModel.OrderedList);
		}

                    private void NameCheckedChanged(object sender, CheckedChangedEventArgs e)
                    {
                              var viewModel = BindingContext as SortFolderViewModel;
                              if (e.Value)
                              {
                                        
                              viewModel.NumberOfDocuments = !e.Value; viewModel.Date = !e.Value; }
                    }
                    private void DateCheckedChanged(object sender, CheckedChangedEventArgs e)
                    {
                              var viewModel = BindingContext as SortFolderViewModel;
                              if (e.Value)
                              {
                                        viewModel.NumberOfDocuments = !e.Value; viewModel.Name = !e.Value;
                              }
                    }
                    private void NumDocCheckedChanged(object sender, CheckedChangedEventArgs e)
                    {
                              var viewModel = BindingContext as SortFolderViewModel;
                              if (e.Value)
                              {
                                        viewModel.Name = !e.Value; viewModel.Date = !e.Value;
                              }
                    }
          }
}