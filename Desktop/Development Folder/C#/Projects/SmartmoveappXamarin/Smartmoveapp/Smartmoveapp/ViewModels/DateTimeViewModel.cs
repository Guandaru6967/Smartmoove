using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.ViewModels
{
          public partial class DateTimeViewModel:ObservableObject
          {
                    [ObservableProperty]
                    DateTime dateTimeSelected = DateTime.Now;

          }
}
