using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.ViewModels
{
    public partial class LockFolderViewModel:ObservableObject
    {
                    [ObservableProperty]
                    Folder folder = new Folder();
                    [ObservableProperty]
                    string passCode = string.Empty;
                    [ObservableProperty]
                    bool codeVisibility=false;
                    public LockFolderViewModel(ref Folder _folder) 
                    {
                              Folder = _folder;
                    }
    }
}
