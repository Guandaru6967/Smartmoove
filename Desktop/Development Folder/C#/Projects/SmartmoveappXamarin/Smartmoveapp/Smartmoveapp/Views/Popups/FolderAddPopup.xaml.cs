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
          public partial class FolderAddPopup : Popup
          {
                    public FolderAddPopup()
                    {
                              InitializeComponent();
                    }
                    private void AddManually(object sender,EventArgs e) 
                    {
                              this.Dismiss(true);
                    }
                    private void AddFromScan(object sender,EventArgs e) 
                    {
                              this.Dismiss(false);
                    }
          }
}