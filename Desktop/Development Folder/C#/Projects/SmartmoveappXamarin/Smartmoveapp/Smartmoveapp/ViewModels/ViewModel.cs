using CommunityToolkit.Mvvm.ComponentModel;
using PanCardView.Extensions;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using System.Drawing;
using SkiaSharp;
namespace Smartmoveapp.ViewModels
{
  
          public partial class DocumentTypeActive : ObservableObject
          {
                    [ObservableProperty]
                    bool invoiceActive  =true;
                    [ObservableProperty]
                    bool contractActive = true;
                    [ObservableProperty]
                    bool informationActive  = true;
                    [ObservableProperty]
                    bool favouriteActive = false;
                    [ObservableProperty]
                    bool agentActive = false;

          }
    public class DocumentAttributes : ObservableCollection<(Type,object)>
    {
        public string Header { get; set; }
        public ObservableCollection<(Type,object)> Folderlist => this;
     
    }
          public partial class FolderPanelViewModel : ObservableObject 
          {
           
                    /// <summary>
                    /// variable for the max opacity value
                    /// </summary>
                    private const double MaxOpacity = 0.5;

                    /// <summary>
                    /// Is expanded value
                    /// </summary>
                    private bool _IsExpanded;

                    /// <summary>
                    /// Is visible value
                    /// </summary>
                    private bool _IsVisible = false;

                    /// <summary>
                    /// Is Y value
                    /// </summary>
                    private double _ExpandedPercentage;

                    /// <summary>
                    /// Is overlay visible / opacity
                    /// </summary>
                    private double _OverlayOpacity;

                    /// <summary>
                    /// The bottom drawer lock states
                    ///
                    /// Note: [alex-d] works incorrectly when more than 3 values
                    /// private double[] _LockStates = new double[] { 0, .30, 0.6, 0.95 };
                    /// </summary>
                    private double[] _LockStates = new double[] { 0, .50, 0.75 };


   
                    /// <summary>
                    /// On background clicked
                    /// </summary>
                    /// <summary>
                    /// Is ExpandedPercentage
                    /// </summary>
                    public double ExpandedPercentage
                    {
                              get => _ExpandedPercentage;
                              set
                              {
                                        SetProperty(ref _ExpandedPercentage, value);
                                        OverlayOpacity = MaxOpacity < value ? MaxOpacity : value;
                              }
                    }

                    /// <summary>
                    /// Lock states
                    /// </summary>
                    public double[] LockStates
                    {
                              get => _LockStates;
                              set => SetProperty(ref _LockStates, value);
                    }

                    /// <summary>
                    /// Is expanded
                    /// </summary>
                    public bool IsExpanded
                    {
                              get => _IsExpanded;
                              set => SetProperty(ref _IsExpanded, value);
                    }

                    /// <summary>
                    /// Is visible
                    /// </summary>
                    public bool IsVisible
                    {
                              get => _IsVisible;
                              set => SetProperty(ref _IsVisible, value);
                    }

                    /// <summary>
                    /// Is layout opacity value
                    /// </summary>
                    public double OverlayOpacity
                    {
                              get => _OverlayOpacity;
                              set => SetProperty(ref _OverlayOpacity, value);
                    }

          }
          public partial class FolderGroup : List<Folder> 
          {
                    public string Name { get; set; } = string.Empty;
                    public FolderGroup(List<Folder> listing,string name) :base (listing)
                    {

                              Name = name;
                    }
          }
          public partial class FilterState : DocumentTypeActive
          {

          }
          public partial class SortingState : ObservableObject 
          {
                    [ObservableProperty]
                    bool name = true;
                    [ObservableProperty]
                    bool date = false;
                    [ObservableProperty]
                    bool numberOfDocuments = false;
          }
          public partial class HomeViewModel:ObservableObject 
    {
                    [ObservableProperty]
                    bool folderOptionsOpen = false;
                    [ObservableProperty]
                    bool isFoldersRefreshing = false;
                    [ObservableProperty]
                    string passCode  = "123456";
                    [ObservableProperty]
                    FolderPanelViewModel folderPanelViewModel = new FolderPanelViewModel() { };
                    [ObservableProperty]
                      bool viewPassCode  = true;
                    [ObservableProperty]
                     (double, double)[] location  = { (4555.55, 32235.666), (5545.55, 234.676) };
                    [ObservableProperty]
                    ObservableCollection<SmartDocument> documents;
                    [ObservableProperty]
                    [NotifyPropertyChangedFor(nameof(HasAgencies))]
                      List<Agency> agencies = new List<Agency>
           {
              new Agency
{
    Id = 13,
    Name = "Allianz",
    Address = "321 Downtown Avenue",
    Rating = 4.0,
    Ratingcount = 98,
    Position = new Tuple<double, double>(34.0522, -118.2437),
    Email = "allianz@operations.com",
    Tel = "555-4545",
    Phone = "555-5656"
},

new Agency
{
    Id = 14,
    Name = "Ergo",
    Address = "654 Explorer Road",
    Rating = 4.6,
    Ratingcount = 112,
    Position = new Tuple<double, double>(40.7128, -74.0060),
    Email = "info@ergo.com",
    Tel = "555-6767",
    Phone = "555-7878"
},

new Agency
{
    Id = 15,
    Name = "InsureGuard Solutions",
    Address = "987 Safety Lane",
    Rating = 3.8,
    Ratingcount = 76,
    Position = new Tuple<double, double>(37.7749, -122.4194),
    Email = "info@insureguard.com",
    Tel = "555-8989",
    Phone = "555-0909"
},
new Agency
{
    Id = 16,
    Name = "Sunrise Estates",
    Address = "123 Morning Avenue",
    Rating = 4.3,
    Ratingcount = 94,
    Position = new Tuple<double, double>(41.8781, -87.6298),
    Email = "info@sunriseestates.com",
    Tel = "555-1122",
    Phone = "555-3344"
},

new Agency
{
    Id = 17,
    Name = "Wanderlust Getaways",
    Address = "456 Explore Road",
    Rating = 4.9,
    Ratingcount = 130,
    Position = new Tuple<double, double>(34.0522, -118.2437),
    Email = "info@wanderlustgetaways.com",
    Tel = "555-5566",
    Phone = "555-7788"
},

new Agency
{
    Id = 18,
    Name = "Secure Shield Insurances",
    Address = "789 Safety Street",
    Rating = 4.2,
    Ratingcount = 85,
    Position = new Tuple<double, double>(40.7128, -74.0060),
    Email = "info@secureshield.com",
    Tel = "555-9900",
    Phone = "555-1122"
},


           };
                    public FilterState FilterState = new FilterState();
                    public SortingState SortState = new SortingState();
                    public bool HasAgencies => Agencies.Count()>0;
                    [ObservableProperty]
                    [NotifyPropertyChangedFor(nameof(FolderGroups))]
                    List<Folder> folders = new List<Folder>
        {
            new Folder
            {
                FolderName="Allianz",
                Created_Dt=DateTime.Now,
                LockCode="123456",
                CustomerId=1,
                 ContractPartnerId=2,
                 FolderId=1,
                Documents= new List<SmartDocument>{
                  new SmartDocument
                  { 
                      Created_Dt=DateTime.Now,
                            Modified_dt=DateTime.UtcNow,
                            Name="Board of Directors Memo",
                            FileType="PDF",
                            DocType="INFO",AgentId=13,
                            InfoDetail=new InfoDetail
                            {
                                Id=1,
                                Name="Internal Memo ",
                                Created_Dt=DateTime.Now,
                                Notes="gdjethreherwh\n" +
                                "srehwerhwerherh\n" +
                                "erhewrhesrhewrh\n" +
                                "erherhwerherwhewh\n"
                            },
                            FolderId=1,
                            Id=2},
                  new SmartDocument
                  { Created_Dt=DateTime.Now,
                            Modified_dt=DateTime.UtcNow,
                            Name="Invoice 1234",
                            FolderId=1,
                            DocType="INVOICE",
                            InvoiceDetail=new InvoiceDetail
                            {
                                Name="Invoice 101",
                                Created_Dt=DateTime.Now,
                                Modified_dt=DateTime.Today,
                                Currency="USD",
                                Notes="21rwgwrhtr" +
                                "weqewgergrg" +
                                "rehe5yhwrghetj" +
                                "tyjetyjtherhtwrh" +
                                "rhwrehwerhewrh",
                                Tax=21.21,


                            },
                            Id=2
                        },
                   new SmartDocument { Created_Dt=DateTime.Now,
                            Modified_dt=DateTime.UtcNow,
                            Name="Contract 101",
                            FolderId=1,
                       ContractDetail=new ContractDetail
                       {
                           InfoDt=DateTime.Now,
                           InfoSubject="Developer Contract",
                           StartDate=DateTime.FromBinary(3253252),
                           EndDate= DateTime.Now,
                           AutomatedContractExtension=false,
                           ContractNr="Alianz",
                           Notes="wrehqerhwg" +
                           "rbhrwhwrhtwrht" +
                           "ergewgwerewrgerg"+
                           "ewgrbrwtrbwrb",
                           CustomerNr="Shirly",
                           
                       },
                            DocType="CONTRACT",
                            Id=2
                        },

                }
            }
             ,new Folder()
                     {
             FolderName="Elir",
             Created_Dt=DateTime.Now,
             LockCode="",
             CustomerId=1,
              ContractPartnerId=2,
              FolderId=3,
             Documents={
               new SmartDocument()
               { Created_Dt=DateTime.Now,
                         Modified_dt=DateTime.UtcNow,
                         Name="PDF 202",
                         FileType="PDF",
                         AgentId=14,
                         DocType="INFO",
                         InfoDetail=new InfoDetail()
                         {
                             Id=1,
                             Name="Info 202",
                             Created_Dt=DateTime.Now,
                             Notes="gdjethreherwh\n" +
                             "srehwerhwerherh\n" +
                             "erhewrhesrhewrh\n" +
                             "erherhwerherwhewh\n"
                         },
                         FolderId=1,
                         Id=2},
               new SmartDocument()
               { Created_Dt=DateTime.Now,
                         Modified_dt=DateTime.UtcNow,
                         Name="Invoice 202",
                         FolderId=1,
                         AgentId=15,
                         DocType="INVOICE",
                         InvoiceDetail=new InvoiceDetail()
                         {
                             Name="Invoice 101",
                             Created_Dt=DateTime.Now,
                             Modified_dt=DateTime.Today,
                             Currency="USD",
                             Notes="21rwgwrhtr" +
                             "weqewgergrg" +
                             "rehe5yhwrghetj" +
                             "tyjetyjtherhtwrh" +
                             "rhwrehwerhewrh",
                             Tax=21.21,


                         },
                         Id=2
                     },
                new SmartDocument() { Created_Dt=DateTime.Now,
                         Modified_dt=DateTime.UtcNow,
                         Name="Contract 202",
                         FolderId=1,
                    ContractDetail=new ContractDetail()
                    {
                        InfoDt=DateTime.Now,
                        InfoSubject="Developer Contract",
                        StartDate=DateTime.FromBinary(3253252),
                        EndDate= DateTime.Now,
                        AutomatedContractExtension=false,
                        ContractNr="Alianz",
                        Notes="wrehqerhwg" +
                        "rbhrwhwrhtwrht" +
                        "ergewgwerewrgerg"+
                        "ewgrbrwtrbwrb",
                        CustomerNr="Shirly",
                    },
                         DocType="CONTRACT",
                         Id=2
                     },

             }
         }
         ,new Folder()
         {
             FolderName="Ergo",
             Created_Dt=DateTime.Now,
             LockCode="123456",
             
             CustomerId=1,
              ContractPartnerId=2,
              FolderId=2,
             Documents={
               new SmartDocument()
               { Created_Dt=DateTime.Now,
                         Modified_dt=DateTime.UtcNow,
                         Name="PDF 101",
                         FileType="PDF",
                         AgentId=13,
                         DocType="INFO",
                         InfoDetail=new InfoDetail()
                         {
                             Id=1,
                             Name="PDF",
                             Created_Dt=DateTime.Now,
                             Notes="gdjethreherwh\n" +
                             "srehwerhwerherh\n" +
                             "erhewrhesrhewrh\n" +
                             "erherhwerherwhewh\n"
                         },
                         FolderId=1,
                         Id=2},
               new SmartDocument()
               { Created_Dt=DateTime.Now,
                         Modified_dt=DateTime.UtcNow,
                         Name="Invoice 303",
                         FolderId=1,
                         DocType="INVOICE",
                         InvoiceDetail=new InvoiceDetail()
                         {
                             Name="Invoice 202",
                             Created_Dt=DateTime.Now,
                             Modified_dt=DateTime.Today,
                             Currency="USD",
                             Notes="21rwgwrhtr" +
                             "weqewgergrg" +
                             "rehe5yhwrghetj" +
                             "tyjetyjtherhtwrh" +
                             "rhwrehwerhewrh",
                             Tax=21.21,
                             TotalPrice=51.21

                         },
                         Id=2
                     },
                new SmartDocument() { Created_Dt=DateTime.Now,
                         Modified_dt=DateTime.UtcNow,
                         Name="Contract 303",
                         FolderId=1,
                         AgentId=18,
                    ContractDetail=new ContractDetail()
                    {
                        InfoDt=DateTime.Now,
                        InfoSubject="Developer Contract",
                        StartDate=DateTime.FromBinary(3253252),
                        EndDate= DateTime.Now,
                        AutomatedContractExtension=false,
                        ContractNr="Alianz",
                        Notes="wrehqerhwg" +
                        "rbhrwhwrhtwrht" +
                        "ergewgwerewrgerg"+
                        "ewgrbrwtrbwrb",
                        CustomerNr="Shirly",
                    },
                         DocType="CONTRACT",
                         Id=2
                     },

             }
         }
    };
                    [ObservableProperty]
                    [NotifyPropertyChangedFor(nameof(FolderGroups))]
                    List<Folder> folderListing = new List<Folder>();
                    [ObservableProperty]
                    bool searchActive = false;
                    public List<FolderGroup> FolderGroups { get 
                              {
                                        List<FolderGroup> groups= new List<FolderGroup>();
                                        string[] letters = FolderListing.Select(x=>x.FolderName).Select(x=>x.First().ToString()).ToList().Distinct().ToArray();
                                        foreach(var letter in letters) 
                                        {
                                                  FolderGroup group = new FolderGroup(FolderListing.Where(x=>x.FolderName.First().ToString()==letter).ToList(),letter);
                                                  groups.Add(group);
                                        }
                                        return groups;
                              } }
                    [ObservableProperty]
                    [NotifyPropertyChangedFor(nameof(FolderViewIcon))]
                    bool isFolderView=true;
                    public string FolderViewIcon => IsFolderView ? "Smartmoveapp.Assets.labelled.listview.png" :"Smartmoveapp.Assets.labelled.gridview.png";
                    public HomeViewModel() 
                    {
                              FolderListing.AddRange(Folders);
                    }
    }
}
