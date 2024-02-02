
using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
namespace Smartmoveapp.ViewModels
{
          public partial class DocFeedBackViewModel : ObservableObject {

                    [ObservableProperty]
                    SmartDocument document = new SmartDocument();
                    [ObservableProperty]
                    ImageObject imageTaken=new ImageObject();
                    [ObservableProperty]
                    Folder folder = new Folder { };
                    [ObservableProperty]
                    bool isBusy = true;
                    public DocFeedBackViewModel()
                    {
                              var listing = new List<SmartDocument>()
                              {
                                        new SmartDocument{AgentId=14,Created_Dt=DateTime.Now,DocType="INFO",InfoDetail=new InfoDetail{Name="Board of Directors Memo" ,InfoDt=DateTime.Now.AddDays(-1),InfoSubject="Board of Directors Memo"} },
                                        new SmartDocument{AgentId=2,Created_Dt=DateTime.Now,DocType="CONTRACT",ContractDetail=new ContractDetail{ Created_Dt=DateTime.Now,Name="Contract",EndDate=DateTime.Now.AddDays(10),AutomatedContractExtension=false,CancelDeadline=DateTime.Now.AddDays(10),StartDate=DateTime.Now.AddDays(-5),CustomerNr=Guid.NewGuid().ToString(),ContractNr=Guid.NewGuid().ToString(),Notes="Pool Contract"} },
                                        new SmartDocument{ AgentId=0,Created_Dt=DateTime.Now,DocType="INVOICE",InvoiceDetail=new InvoiceDetail{ Created_Dt=DateTime.Now,Name="invoice test",Id=32414,PriceNet=4500.00,Tax=100.00,Notes="Paid by cash",TotalPrice=4600.00,Currency="EUR",DocumentId=12412},FileType="Document" }
                              };

                              Random random = new Random();
                              Document=listing[random.Next(0, listing.Count - 1)];

                    } 
          }
                  


}