using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views.Popups
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FolderOptions : Popup
	{
		public FolderOptions (ref List<Folder> folders,ref  Folder folder)
		{
			InitializeComponent ();
			BindingContext= new FolderOptionsViewModel(ref folders, ref  folder);
		}
		public void ToggleFavourite(object sender,EventArgs e) 
		{
                              var viewModel = BindingContext as FolderOptionsViewModel;
			if (viewModel.Folder != null)
			{
				viewModel.Folder.IsFavourite = !viewModel.Folder.IsFavourite;
			}
		

                    }
		public void Rename(object sender,EventArgs e) 
		{
			this.Dismiss(null);
			var viewModel = BindingContext as FolderOptionsViewModel;
			this.ShowPopup(new RenameFolder(viewModel.Folder));
                              this.Dismiss(viewModel.Folders);
                    }
		public async void Delete(object sender,EventArgs e) 
		{
			var viewModel = BindingContext as FolderOptionsViewModel;
			var folders= viewModel.Folders;
			var folder = viewModel.Folder;
			
                              this.Dismiss(await this.ShowPopupAsync(new FolderConfirmDelete(ref folder, ref folders)));
                    }	
		public void LockFolder(object sender,EventArgs e) 
		{
                              var viewModel = BindingContext as FolderOptionsViewModel;
                              this.ShowPopup(new LockFolder(viewModel.Folder));
                              this.Dismiss(viewModel.Folders);
                    }
		public void CloseOptions(object sender,EventArgs e) 
		{
                              var viewModel = BindingContext as FolderOptionsViewModel;
                              this.Dismiss(viewModel.Folders);
                    }
		private void ChangePassCode(object sender,EventArgs e) 
		{
			var viewModel=BindingContext as FolderOptionsViewModel;
			var folder = viewModel.Folder;
			this.ShowPopup(new ChangeCodePopup(ref folder));
                              this.Dismiss(viewModel.Folders);
                    }

          }
}