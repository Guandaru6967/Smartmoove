using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views.Popups
{
          [XamlCompilation(XamlCompilationOptions.Compile)]
          public partial class ImageViewPopup : Popup
          {
                    public ImageViewPopup(ImageObject imageobject)
                    {
                              InitializeComponent();
                              Debug.WriteLine("Showing view");
                              BindingContext = imageobject;
                              Debug.WriteLine("Shown view");
                    }
                    public void AcceptImage(object sender,EventArgs e) 
                    {
                              this.Dismiss(true);
                    }
                    public void RemoveImage(object sender, EventArgs e)
                    {
                              this.Dismiss(false);
                    }
          }
}