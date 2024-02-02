using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Smartmoveapp.ViewModels
{
  partial  class DeleteViewModel:ObservableObject
    {
                    [ObservableProperty]
                    List<Folder> folders = new List<Folder>();
                    [ObservableProperty]
                    Folder folder = new Folder();
                    public DeleteViewModel(Folder _folder, List<Folder> _folders) 
                    {
                              Folders = _folders;
                              Folder = _folder;
                    }
    }
}
