using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.Models
{
          public partial class Agency : ObservableObject
          {
                    [ObservableProperty]
                    private int id;
                    [ObservableProperty]
                    private string name = string.Empty;
                    [ObservableProperty]
                    private string address=string.Empty;
                    [ObservableProperty]
                    private double rating = 3.0;
                    [ObservableProperty]
                    private int ratingcount = 82;
                    [ObservableProperty]
                    private Tuple<double, double> position;
                    [ObservableProperty]
                    string email = string.Empty;
                    [ObservableProperty]
                    string tel= string.Empty;
                    [ObservableProperty]
                    string phone= string.Empty;
                    [ObservableProperty]
                    string sensitiveCode = string.Empty;
          }

}
