using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.ViewModels
{
          public  partial class DocumentViewModel:ObservableObject
          {
                    [ObservableProperty]
                    SmartDocument document=new SmartDocument();
          }
}
