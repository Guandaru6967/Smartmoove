using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RenameFolder : Xamarin.CommunityToolkit.UI.Views.Popup
    {

        public RenameFolder()
        {
            InitializeComponent();
        }
    }
}