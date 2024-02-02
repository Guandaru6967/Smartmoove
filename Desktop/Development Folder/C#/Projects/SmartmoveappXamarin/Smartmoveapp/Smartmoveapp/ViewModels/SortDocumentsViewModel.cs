using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartmoveapp.ViewModels
{
          public partial  class SortDocumentsViewModel:ObservableObject
          {
                    [ObservableProperty]
                    bool isReverse = false;
                    [ObservableProperty]
                     List<SmartDocument> documents = new List<SmartDocument>();
                    [ObservableProperty]
                    bool name = false;
                    [ObservableProperty]
                    bool date = false;
                    public List<SmartDocument> SortedDocuments 
                    {
                              get 
                              {
                                        var listing=new List<SmartDocument>();
                                        if (Name)
                                        {
                                                  listing= Documents.OrderBy(d => d.Name).ToList();
                                        }
                                        else if (Date) 
                                        {
                                                  listing= Documents.OrderBy(x=>x.Created_Dt).ToList();
                                        }
                                        else
                                        {
                                                  listing= Documents;

                                        }
                                        if (IsReverse)
                                        {
                                                  listing.Reverse();
                                        }
                                        return listing;
                              }
                    }
                    }
}
