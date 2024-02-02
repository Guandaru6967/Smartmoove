using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Smartmoveapp.ViewModels
{
    public  partial class FolderOptionsViewModel:ObservableObject
    {
                    [ObservableProperty]
                    List<Folder>folders = new List<Folder>();
                    [ObservableProperty]
                    Folder folder=new Folder();
                    public FolderOptionsViewModel(ref List<Folder> _folders,ref Folder _folder) 
                    {
                              Folders = _folders;
                              Folder = _folder;
                    }
    }
}
