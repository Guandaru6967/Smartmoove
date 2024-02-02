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
	public partial class ChangeFolderCode : Popup
	{
		public ChangeFolderCode (Folder folder)
		{
			InitializeComponent ();
			BindingContext = new ChangeFolderCodeViewModel(folder);
		}
		public async void ChangePassCode(object sender,EventArgs e) 
		{
			var viewModel=BindingContext as ChangeFolderCodeViewModel;
			
			if (viewModel.NewCode == string.Empty) 
			{
			await 	this.DisplayToastAsync("must enter new code! ");
			}
			if (viewModel.OldCode==viewModel.NewCode) 
			{
                                        await this.DisplayToastAsync("old code must be different from new code! ");
                              }
			else 
			{

			}
		}
	}
}