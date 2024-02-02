using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartmoveapp.ViewModels
{
          public partial class SortFolderViewModel : ObservableObject
          {
                    [ObservableProperty]
                    List<Folder> folders = null;
                    [ObservableProperty]
                    bool isReverse = false;
                    [ObservableProperty]
                    bool name = true;
                    [ObservableProperty]
                    bool date = false;
                    [ObservableProperty]
                    bool numberOfDocuments = false;
                    public List<Folder> OrderedList { get
                              {
                              
                                        
                                                  if (Name)
                                                  {

                                                  Folders=Folders.OrderBy(x => x.FolderName).ToList();


                                                  }
                                                  if (Date)
                                                  {
                                                  Folders = Folders.OrderBy(x => x.Created_Dt).ToList();
                                                  }
                                                  if (NumberOfDocuments)
                                                  {
                                                  Folders = Folders.OrderBy(x => x.Documents.Count).ToList();
                                                  }
                                        if (IsReverse) 
                                        {
                                                  Folders.Reverse();
                                        }
                                        
                                        return Folders;
                              }

                    }
          }
}
