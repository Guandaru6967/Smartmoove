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
	public partial class LockFolder : Popup
	{
		public LockFolder ( Folder  folder)
		{
			InitializeComponent ();
			BindingContext = new LockFolderViewModel(ref folder);
		}
		public void Cancel(object sender,EventArgs e) 
		{
			this.Dismiss(null);
		}
		public void ToggleCodeVisibility(object sender ,EventArgs e) 
		{
			this.Dismiss(null);
		}

                    public void LockWithCode(object sender,EventArgs e)
			
		{
			var viewModel = BindingContext as LockFolderViewModel;
			viewModel.Folder.LockCode = viewModel.PassCode;
			this.Dismiss(null);
			
		}
	}
}