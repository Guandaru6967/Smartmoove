using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.ViewModels
{
  public partial  class ChangeCodePopupViewModel:ObservableObject
    {
                    [ObservableProperty]
                    Folder folder = null;
                    [ObservableProperty]
                    string newCode = string.Empty;
                    [ObservableProperty]
                    string oldCode=string.Empty;
    }
}
