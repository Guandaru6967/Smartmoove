using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Smartmoveapp.ViewModels
{
          public class DocumentGroup:List<SmartDocument>
          {
                    public string Name { get; set; }= string.Empty;
                    public string DocImage { get { string icon = Name == string.Empty ? "" : Name == "INVOICE" ? "Smartmoveapp.Assets.labelled.solid_file_invoice.png" : Name == "INFO" ? "Smartmoveapp.Assets.labelled.solid_file.png" : Name == "CONTRACT" ? "Smartmoveapp.Assets.labelled.solid_file_contract.png" : "";
                                        return icon; } }
                    public DocumentGroup(List<SmartDocument> folders,string name ) :base(folders)
                    {
                              Name = name;
                    }
          }
          public partial class FolderPageViewModel:ObservableObject
          {
                    [ObservableProperty]
                    [NotifyPropertyChangedFor(nameof(IsListView))]
                    bool isGridView = true;
                    [ObservableProperty]
                    bool isSearch = false;
                    public bool IsListView => !IsGridView;
                    public string FolderView;
                    [ObservableProperty]
                    Folder folder = new();
                    public string DocumentViewIcon => IsListView ? "Smartmoveapp.Assets.labelled.listview.png" : "Smartmoveapp.Assets.labelled.gridview.png";
                    [ObservableProperty]
                    ObservableCollection<SmartDocument> folderDocuments= new ObservableCollection<SmartDocument>();       
                    public List<DocumentGroup> SmartDocumentGroups { get 
                              {
                                        var groups = new List<DocumentGroup>();
                                        string[] doctypes = Folder.Documents.Select(x => x.DocType).Distinct().ToArray(); 
                                        foreach(var doctype in doctypes) 
                                        {
                                                  DocumentGroup group = new DocumentGroup(Folder.Documents.Where(x=>x.DocType==doctype).ToList(),doctype);
                                                  groups.Add(group);
                                        }
                                        return groups;
                              } }
                    public FolderPageViewModel()
                    {
                              this.PropertyChanged += this.ChangedProperty;
                         
                    }
                    private void ChangedProperty(object sender,PropertyChangedEventArgs e) 
                    {

                              if(e.PropertyName== nameof(Folder))
                              {
                                        FolderDocuments = new ObservableCollection<SmartDocument>(Folder.Documents);
                              }
                    }

          }
}
