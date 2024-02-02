using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Smartmoveapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordPrompt : Popup
    {
        public static bool Accepted { get; set; }
        string passcode = string.Empty;
        public PasswordPrompt(string code)
        {
            InitializeComponent();
                              passcode = code;
                              
        }
        private void ToggleView(object sender, EventArgs args)
        {
            passcodeentry.IsPassword = !passcodeentry.IsPassword;
        }
        private async void SetPassCode(object sender,EventArgs e)
          {
                              var viewmodel = BindingContext as PasswordViewModel;
                               
                              await this.DisplayToastAsync("Successfully locked folders with new passcode");
                    }      
        private async void CheckPass(object sender, EventArgs e)
        {
            var viewmodel = BindingContext as PasswordViewModel;
            passcode = await SecureStorage.GetAsync("passcode");
          viewmodel.StoredPassCode = passcode;
          if (passcode != null&&passcode!=string.Empty) 
          {
                    viewmodel.HasPassCode = true;
          }
          else 
          {
                    viewmodel.HasPassCode = false;
          }
             if (viewmodel.StoredPassCode == viewmodel.PassCode)
            {
                    Dismiss(null);
            }
            else
            {
                var snackbaropt = new SnackBarOptions {
                    BackgroundColor = (Color)Application.Current.Resources["themecolorf"],
                    Duration = TimeSpan.FromSeconds(3),
                    CornerRadius=10,
                       
                    Actions = new[] { new SnackBarActionOptions { Action = new Func<Task>(() => new Task(()=>viewmodel.PassCode="")),} },
                    MessageOptions=new MessageOptions() 
                    {
                      
                        Padding=10,
                        Foreground = (Color)Application.Current.Resources["themecolora"],
                        Message="Incorrect Password ,Please try again!"},
                };
                await this.DisplaySnackBarAsync(snackbaropt);
            }
        }
    }
}