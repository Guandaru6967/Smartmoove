using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
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
	public partial class ChangeCodePopup : Popup
	{
		public ChangeCodePopup (ref Folder folder)
		{
			InitializeComponent ();
			BindingContext = new ChangeCodePopupViewModel() { };
		}
		private async void ChangeFolderCode(object  sender,EventArgs e) 
		{
			var viewModel=BindingContext as ChangeCodePopupViewModel;
			if (viewModel.Folder.LockCode == viewModel.OldCode)
			{

				viewModel.Folder.LockCode = viewModel.NewCode;
                                        await this.DisplayToastAsync($"Password for {viewModel.Folder.FolderName} as been changed successfully .");
                              }
			else 
			{
				await this.DisplayToastAsync("Incorrect password");
			}
		}
		private void Close(object sender, EventArgs e) 
		{
			this.Dismiss(null);
		}
	}
}