using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views.Popups
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FolderConfirmDelete : Popup
	{
		public FolderConfirmDelete (ref Folder  folder,ref List<Folder> folders)
		{
			InitializeComponent ();
			BindingContext = new DeleteViewModel(folder,folders);
		}
		public void DeleteFolder(object sender,EventArgs e) 
		{
			var viewModel = BindingContext as DeleteViewModel ;
			viewModel.Folders.Remove(viewModel.Folder);
			this.Dismiss(viewModel.Folders);
		}
		public void CancelDelete(object sender,EventArgs e)
		{
                              var viewModel = BindingContext as DeleteViewModel;
                              this.Dismiss(viewModel.Folders);

		}
	}
}