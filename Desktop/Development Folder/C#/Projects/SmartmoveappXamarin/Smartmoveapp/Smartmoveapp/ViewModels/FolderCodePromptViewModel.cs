using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.ViewModels
{
    partial class FolderCodePromptViewModel:ObservableObject
    {
                    [ObservableProperty]
                    string folderCode = string.Empty;
                    [ObservableProperty]
                    string keyCode = string.Empty;

    }
}
