using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartmoveapp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatePicker : Xamarin.CommunityToolkit.UI.Views.Popup
          {
                    public Folder Folder;
                    public SmartDocument Document;
                    public DatePicker()
                    {
                              InitializeComponent();
           
                    }
                    public void DateSelected(object sender,EventArgs e) 
                    {
                              var viewmodel=BindingContext as DateTimeViewModel;
                              Dismiss(viewmodel.DateTimeSelected);
                    }
               
    }
}