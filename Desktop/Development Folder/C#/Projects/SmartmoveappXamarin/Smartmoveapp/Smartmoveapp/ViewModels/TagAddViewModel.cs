using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.ViewModels
{
          public partial class TagAddViewModel:ObservableObject
          {
                    [ObservableProperty]
                    string tagText = string.Empty;
          }
}
