using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.ViewModels
{
          public partial class PasswordViewModel:ObservableObject
          {
                    [ObservableProperty]
                    string passCode = string.Empty;
                    [ObservableProperty]
                    bool hasPassCode = false;
                    [ObservableProperty]
                    string storedPassCode=string.Empty;
          }
}
