using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.ViewModels
{
          public partial  class DocumentEditingViewModel:ScanningPageViewModel
          {
                    [ObservableProperty]
                    ImageObject currentImage = new ImageObject();
                    [ObservableProperty]
                    List<ImageObject> images = new List<ImageObject>();
               
          }
}
