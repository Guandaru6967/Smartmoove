using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Smartmoveapp.ViewModels
{
          public partial  class FolderFilterViewModel : ObservableObject
          {
                    [ObservableProperty]
                    DocumentTypeActive docPanelSwitch = new DocumentTypeActive();
                    [ObservableProperty]
                    bool favouriteActive = false;
                    [ObservableProperty]
                    bool agentActive = false;
                  
                    public List<Folder> Folders { get; set; } 
          }
          
}
