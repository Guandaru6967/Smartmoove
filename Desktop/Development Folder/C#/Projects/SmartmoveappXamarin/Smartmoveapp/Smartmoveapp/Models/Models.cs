using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms.Maps;



namespace Smartmoveapp.Models
{
         
          public partial class CustomPin : Pin
          {
                    public string Name { get; set; }
                    public string Url { get; set; }
                    public double Rating { get; set; } = 3;
                    public int RatingCount { get; set; } = 82;
          }

}
