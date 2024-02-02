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
    public partial class DocView : ContentPage
    {
        public class PDFDocView : WebView
        {
            public static readonly BindableProperty UriProperty = BindableProperty.Create(propertyName: "Uri",
                    returnType: typeof(string),
                    declaringType: typeof(PDFDocView),
                    defaultValue: default(string));

            public string Uri
            {
                get { return (string)GetValue(UriProperty); }
                set { SetValue(UriProperty, value); }
            }
        }

        public DocView()
        {
            InitializeComponent();
            var doc = new PDFDocView();
            doc.Uri="https://www.ssw.jku.at/Teaching/Lectures/CSharp/Tutorial/Part1.pdf";

            Content = doc;
        }
        public DocView(string Source)
        {
            InitializeComponent();
            Content=new PDFView(Source);
        }
    }
}