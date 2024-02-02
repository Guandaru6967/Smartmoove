using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.Models
{
          public partial class Folder : ObservableObject
          {
                    [ObservableProperty]
                     int folderId = new int();
                    [ObservableProperty]
                     string folderName = string.Empty;
                    [ObservableProperty]
                     DateTime created_Dt = DateTime.MinValue;
                    [ObservableProperty]
                     DateTime modified_Dt = DateTime.MinValue;
                    [ObservableProperty]
                     int customerId = new int();
                    [ObservableProperty]
                     int contractPartnerId = new int();
                    [ObservableProperty]
                     string lockCode = string.Empty;

                    [ObservableProperty]
                     List<SmartDocument> documents = new List<SmartDocument>();
                    [ObservableProperty]
                    bool isFavourite = false;
          }

}
