using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.ViewModels
{
 public partial    class CroppingViewModel:ObservableObject
    {
                    [ObservableProperty]
                    ImageObject imageObject = new ImageObject ();
    }
}
