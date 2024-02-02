using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Smartmoveapp.Controls
{
          public partial class ActionItem : ContentView
          {

                    public int LabelFontSize { get => (int)GetValue(LabelFontSizeProperty); set => SetValue(LabelFontSizeProperty, value); }
                    public string LabelText { get => (string)GetValue(LabelTextProperty); set => SetValue(LabelTextProperty, value); }

                    public string ButtonIcon { get => (string)GetValue(ButtonIconProperty); set => SetValue(ButtonIconProperty, value); }
                    public double ButtonSize { get => (double)GetValue(ButtonSizeProperty); set => SetValue(ButtonSizeProperty, value); }
                    public int ButtonFontSize { get => (int)GetValue(ButtonFontSizeProperty); set => SetValue(ButtonFontSizeProperty, value); }

                    public int CornerRadius { get => (int)GetValue(CornerRadiusProperty); set => SetValue(CornerRadiusProperty, value); }

                    public int Index { get; set; }





                    public static readonly BindableProperty LabelFontSizeProperty = BindableProperty.Create(nameof(LabelFontSize), typeof(int), typeof(ActionItem), 20);
                    public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(nameof(LabelText), typeof(string), typeof(ActionItem), "Menu Item");

                    public static readonly BindableProperty ButtonSizeProperty = BindableProperty.Create(nameof(ButtonSize), typeof(double), typeof(ActionItem), 30.0);
                    public static readonly BindableProperty ButtonIconProperty = BindableProperty.Create(nameof(ButtonIcon), typeof(string), typeof(ActionItem), "add");
                    public static readonly BindableProperty ButtonFontSizeProperty = BindableProperty.Create(nameof(ButtonFontSize), typeof(int), typeof(ActionItem), 20);
                    public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(ActionItem), 15);
                    public static readonly BindableProperty ButtonCommandProperty = BindableProperty.Create(nameof(ButtonCommand), typeof(ICommand), typeof(ActionItem));
                    //public static readonly BindableProperty ButtonClickedProperty = BindableProperty.Create(nameof(ButtonClicked), typeof(EventHandler), typeof(ActionItem));

                    public ICommand ButtonCommand { get => (ICommand)GetValue(ButtonCommandProperty); set => SetValue(ButtonCommandProperty, value); }
                    public void Open()
                    {

                              if (Content != null)
                              {
                                        Content.IsVisible = true;
                              }
                    }


                    public void Close()
                    {
                              if (Content != null)
                              {
                                        Content.IsVisible = false;
                              }
                    }
          }

}
