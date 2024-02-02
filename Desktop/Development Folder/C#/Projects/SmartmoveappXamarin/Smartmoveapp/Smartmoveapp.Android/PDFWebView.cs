using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Smartmoveapp.Views;
using System.Text;
using Xamarin.Forms.Platform.Android;
using static Smartmoveapp.Views.DocView;
using Xamarin.Forms;
using Smartmoveapp.Droid;

[assembly: ExportRenderer(typeof(PDFDocView), typeof(CustomWebViewRenderer))]
namespace Smartmoveapp.Droid
{

        public class CustomWebViewRenderer : WebViewRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
            {
                base.OnElementChanged(e);

                if (e.NewElement != null)
                {
                    var customWebView = Element as PDFDocView;
                    Control.Settings.AllowUniversalAccessFromFileURLs = true;
                 
                   // Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///android_asset/Content/{0}", WebUtility.UrlEncode(customWebView.Uri))));
                //Control.LoadUrl("file:///storage/emulated/0/Android/media/com.aero/WhatsApp/Media/WhatsApp Documents/Http.pdf");
                }
            }
        }
}
