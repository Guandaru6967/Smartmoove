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
          public partial class DocumentAddPopup : Popup
          {
                    public DocumentAddPopup()
                    {
                              InitializeComponent();
                    }
                    private void LocalStorage(object sender, EventArgs e) 
                    {
                              this.Dismiss(false);
                    }
                    private void TakePhoto(object sender, EventArgs e) 
                    {
                              this.Dismiss(true);

                    }
          }
}