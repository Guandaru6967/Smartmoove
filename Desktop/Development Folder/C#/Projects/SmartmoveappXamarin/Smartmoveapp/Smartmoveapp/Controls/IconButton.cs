using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Smartmoveapp.Controls
{

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

}
