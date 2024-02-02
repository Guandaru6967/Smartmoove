using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Smartmoveapp.ViewModels
{
    public partial class ChangeFolderCodeViewModel:ObservableObject
    {
                    [ObservableProperty]
                    string oldCode = string.Empty;
                    [ObservableProperty]
                    string newCode = string.Empty;
                    [ObservableProperty]
                    Folder folder = new Folder();
                    [ObservableProperty]
                    ICommand changeCode;
                    public ChangeFolderCodeViewModel(Folder _folder)
                    {
                              Folder= _folder;
                              OldCode= Folder.LockCode;
                    }
    }
}
