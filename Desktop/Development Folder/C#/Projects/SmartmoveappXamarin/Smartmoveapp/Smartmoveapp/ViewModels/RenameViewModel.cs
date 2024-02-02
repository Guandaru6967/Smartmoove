using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.ViewModels
{
    public partial class RenameViewModel:ObservableObject
    {
                    [ObservableProperty]
                    string name=string.Empty;
                    [ObservableProperty]
                    Folder folder=new Folder();
                    public RenameViewModel(Folder _folder) 
                    {
                              
                              Folder = _folder;
                              Name = Folder.FolderName;

                    }
    }
}
