using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	public partial class FolderCodePrompt : Popup
	{
		public FolderCodePrompt (string folderCode)
		{
			InitializeComponent ();
			BindingContext = new FolderCodePromptViewModel() { FolderCode=folderCode};
		}
		public void ConfirmCode(object sender,EventArgs e) 
		{
			var viewModel=BindingContext as FolderCodePromptViewModel;
			Debug.WriteLine(viewModel.FolderCode);
			Debug.WriteLine(viewModel.KeyCode);
			if (viewModel.FolderCode == viewModel.KeyCode) 
			{
				this.Dismiss(true);
			}
			else 
			{
				this.Dismiss(false);
			}
		}
		public void Cancel(object sender, EventArgs e)
		{
			this.Dismiss(null);
		
		}
                    
	}
}