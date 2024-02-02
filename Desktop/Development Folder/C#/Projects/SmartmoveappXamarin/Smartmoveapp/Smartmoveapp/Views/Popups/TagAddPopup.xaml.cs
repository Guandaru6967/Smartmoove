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
          public partial class TagAddPopup : Popup
          {
                    public TagAddPopup()
                    {
                              BindingContext = new TagAddViewModel() { TagText = "" };
                              InitializeComponent();
                          
                    }
                    public void ReturnTagText(object sender,EventArgs e) 
                    {
                              var viewModel=BindingContext as TagAddViewModel;
                              this.Dismiss(viewModel.TagText);
                    }
                    public void Cancel(object sender ,EventArgs e)
                    {
                              this.Dismiss("");

                    }
          }
}