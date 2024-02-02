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
	public partial class RenameFolder : Popup
	{
		public RenameFolder(Folder folder )
		{
			InitializeComponent ();
			BindingContext = new RenameViewModel(folder);
		}
		public void Rename(object sender,EventArgs e )
		{
			var viewModel = BindingContext as RenameViewModel ;
			viewModel.Folder.FolderName = viewModel.Name;
			this.Dismiss(null);
                    }
		public void Cancel(object sender ,EventArgs e) 
		{
			this.Dismiss(null);
		}
	}
}