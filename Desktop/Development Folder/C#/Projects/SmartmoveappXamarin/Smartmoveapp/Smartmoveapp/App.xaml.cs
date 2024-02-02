using FFImageLoading.Helpers.Exif;
using Smartmoveapp.Models;
using Smartmoveapp.Utilities;
using Smartmoveapp.ViewModels;
using Smartmoveapp.Views.Document;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp
{
    public partial class App : Application
    {
                    private IncomingFile IncomingFile=null;
                  public    IncomingFile InComingFile { get { return IncomingFile; } set 
                              
                              {
                                        var folder = new Folder { };
                                        IncomingFile = value;
                                        
                                        MainPage = new NavigationPage(new DocumentEditingPage(new List<ImageObject>() { new ImageObject { ImageData = value.Content ,Id=value.Name} }, ref folder, true));
                              } 
                    }
                    public App()
        {
            InitializeComponent();
                              if (IncomingFile == null)
                              {
                                        MainPage = new NavigationPage(new MainPage());
                              }
                              
                            
        }
        public partial class IconButton : ContentView
        {
            public static readonly BindableProperty ButtonIconProperty = BindableProperty.Create(nameof(ButtonIcon), typeof(string), typeof(IconButton), string.Empty);
            public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(IconButton), string.Empty);
            public static readonly BindableProperty IconFontSizeProperty = BindableProperty.Create(nameof(IconFontSize), typeof(int), typeof(IconButton), 20);
            public static readonly BindableProperty TextFontSizeProperty = BindableProperty.Create(nameof(TextFontSize), typeof(int), typeof(IconButton), 15);
            public string ButtonIcon
            { get => (string)GetValue(ButtonIconProperty); set => SetValue(ButtonIconProperty, value); }
            public string ButtonText
            { get => (string)GetValue(ButtonTextProperty); set => SetValue(ButtonTextProperty, value); }
            public int IconFontSize
            { get => (int)GetValue(IconFontSizeProperty); set => SetValue(IconFontSizeProperty, value); }
            public int TextFontSize { get => (int)GetValue(TextFontSizeProperty); set => SetValue(TextFontSizeProperty, value); }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
