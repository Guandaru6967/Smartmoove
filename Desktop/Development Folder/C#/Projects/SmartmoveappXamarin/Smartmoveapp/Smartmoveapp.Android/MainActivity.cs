using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android;
using System.Collections.Generic;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.PlatformConfiguration;
using Android.Gms.Maps;
using Xamarin.Forms.Maps.Android;
using Android.Content;
using Android.Gms.Maps.Model;
using Xamarin.Forms.Maps;
using Smartmoveapp.Models;
using Smartmoveapp.Views;
using Android.Views;
using Android.Graphics;
using Android.Widget;
using Xamarin.Forms;
using System.IO;
using Smartmoveapp.Utilities;

namespace Smartmoveapp.Droid
{
   
    [Activity(Label = "Smartmoveapp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
          [IntentFilter(new[] { Intent.ActionSend ,Intent.ActionSendMultiple}, Categories = new[] { Intent.CategoryDefault }, DataMimeType = "image/*")]
          public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int RequestLocationId = 0;
        public static Typeface materialfont;
        public static Typeface poppinsfont;
          
        readonly string[] LocationPersmissions =
        {
                Manifest.Permission.AccessFineLocation,
                Manifest.Permission.AccessCoarseLocation,
        };

        protected override void OnStart()
        {
            base.OnStart();
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    RequestPermissions(LocationPersmissions, RequestLocationId);
                }
                else;
            }
        }
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            materialfont = Typeface.CreateFromAsset(Assets, "MaterialIcons - Regular.ttf");
            poppinsfont = Typeface.CreateFromAsset(Assets, "Poppins-Medium.ttf");
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
           Forms.Init(this, savedInstanceState);
            //Extras Init
            //PopUp Menu Renderer Init 
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);
            //Maps Init
            Xamarin.FormsMaps.Init(this,savedInstanceState);
                              //Material Design Init
                              var application = new App();
                              string action = Intent.Action;
                              string type = Intent.Type;
                              System.Diagnostics.Debug.WriteLine("Image Test");
                              System.Diagnostics.Debug.WriteLine(Intent.ActionView.Equals(action));
                              System.Diagnostics.Debug.WriteLine(String.IsNullOrEmpty(type));
           
                              if (Intent.ActionView.Equals(action) && !String.IsNullOrEmpty(type))
                              {
                                        Android.Net.Uri fileUri = Intent.Data;

                                        byte[] fileContent = File.ReadAllBytes(fileUri.Path);
                                        string fileName = fileUri.LastPathSegment;
                                        System.Diagnostics.Debug.WriteLine("Image found");
                                        var incomingFile = new IncomingFile { Name = fileName, Content = fileContent };
                                        application.InComingFile= incomingFile;
                              }
                           
                                        LoadApplication(application);


            
        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}