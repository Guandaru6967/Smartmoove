
using Smartmoveapp.Models;
using Smartmoveapp.Views.Popups;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            return value.ToString();

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value);
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvoiceDetailPage : ContentPage
    {
        public static SmartDocument  Document { get; set; }
        public InvoiceDetailPage()
        {


            InitializeComponent();
        }
        public InvoiceDetailPage(SmartDocument _Document)
        {
            
            InitializeComponent();
            Document = _Document;
                              BindingContext = _Document;
        }
        public async void ToTabPage(object sender, EventArgs args)
        {
            //Navigation.ShowPopup();

            //SharedTransitionNavigationPage.SetTransitionDuration(this, 50);
           
            // var pop= await Navigation.RemovePage(this);
             //await Navigation.PushAsync(pop);
             Navigation.RemovePage(this);
                              

        }
                    private async void AddTag(object sender, EventArgs e)
                    {
                              var viewModel = BindingContext as SmartDocument;
                              var tagpopup = await this.ShowPopupAsync(new TagAddPopup());
                              var tagtext = tagpopup as string;
                              Debug.WriteLine(tagtext);
                              if (tagtext != string.Empty)
                              {
                                        viewModel.Tags.Add(tagtext);
                              }
                    }
        private void OpenDoc(object sender, EventArgs args)
        {


            var page = new DocView();
            Navigation.PushAsync(page, true);
        }

    }

}