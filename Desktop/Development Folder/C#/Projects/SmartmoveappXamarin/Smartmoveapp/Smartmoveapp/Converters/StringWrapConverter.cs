using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.CommunityToolkit.Converters;
using Xamarin.Forms;

namespace Smartmoveapp.Converters
{
          public class StringWrapConverter : IValueConverter
          {
                    public int Value { get; set; } = 6;
                    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                    {
                              var stringvalue = value as string;
                              if (stringvalue.Length > Value)
                              {

                                        return (value as string).Substring(0, Value);
                              }
                              else { return value as string; }
                    }

                    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                    {
                              return (value as string );
                    }
          }
}
