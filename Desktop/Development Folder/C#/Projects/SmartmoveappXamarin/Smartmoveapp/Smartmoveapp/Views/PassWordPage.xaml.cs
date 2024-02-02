
using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassWordPage : Popup
    {
        public PassWordPage()
        {
            InitializeComponent();
        }
       private void TogglePassView(object sender ,EventArgs args)
        {
           passcodeentry.IsPassword=!passcodeentry.IsPassword;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

          await   Navigation.PopAsync(true);
        }
    }
}