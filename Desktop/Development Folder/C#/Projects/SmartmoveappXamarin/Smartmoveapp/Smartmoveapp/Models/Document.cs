using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Smartmoveapp.Models
{

          public partial class SmartDocument : ObservableObject
          {
                    [ObservableProperty]
                    int id = new int();
                    [ObservableProperty]
                    int agentId= new int();
                    [ObservableProperty]
                    bool isFavourite = false;
                    [ObservableProperty]
                    string name = string.Empty;
                    [ObservableProperty]
                    DateTime created_Dt = DateTime.Now;
                    [ObservableProperty]
                    DateTime modified_dt = DateTime.Now;
                    [ObservableProperty]
                    int customerId = new int();
                    [ObservableProperty]
                    string docType = string.Empty;
                    [ObservableProperty]
                    int docTypeId = new int();
                    [ObservableProperty]
                    int folderId = new int();
                    [ObservableProperty]
                    string fileType = string.Empty;
                    [ObservableProperty]
                    string fileUrl = string.Empty;
                    [ObservableProperty]
                    string filePath = string.Empty;
                    [ObservableProperty]
                    object documentbase;
                    [ObservableProperty]
                    string notes = string.Empty;
                    [ObservableProperty]
                    InfoDetail infoDetail = new InfoDetail();
                    [ObservableProperty]
                    InvoiceDetail invoiceDetail;
                    [ObservableProperty]
                    ContractDetail contractDetail;
                    [ObservableProperty]
                    ObservableCollection<string> tags = new ObservableCollection<string>();


          }



          public partial class InfoDetail : ObservableObject
          {
                    [ObservableProperty]
                    int id = new int();
                    [ObservableProperty]
                    string name = string.Empty;
                    [ObservableProperty]
                    DateTime created_Dt = DateTime.MinValue;
                    [ObservableProperty]
                    DateTime modified_dt = DateTime.MinValue;
                    [ObservableProperty]
                    DateTime infoDt = DateTime.MinValue;
                    [ObservableProperty]
                    string infoSubject = string.Empty;
                    [ObservableProperty]
                    int documentId = new int();
                    [ObservableProperty]
                    string contractNr = string.Empty;
                    [ObservableProperty]
                    string customerNr = string.Empty;
                    [ObservableProperty]
                    string notes = string.Empty;
                    [ObservableProperty]
                    bool reminderActive = false;
          }

          public partial class InvoiceDetail : ObservableObject
          {
                    [ObservableProperty]
                    private int id;
                    [ObservableProperty]
                    private int documentId;
                    [ObservableProperty]
                    private string name;
                    [ObservableProperty]
                    private DateTime created_Dt;
                    [ObservableProperty]
                    private DateTime modified_dt;
                    [ObservableProperty]
                    private double totalPrice;
                    [ObservableProperty]
                    private double priceNet;
                    [ObservableProperty]
                    private string currency;
                    [ObservableProperty]
                    private double tax;
                    [ObservableProperty]
                    private object notes;
                    [ObservableProperty]
                    private bool remiderActive;
          }

          public partial class ContractDetail:ObservableObject
          {
                    [ObservableProperty]
                    int id = 0;

                    [ObservableProperty]
                    int documentId = 0;

                    [ObservableProperty]
                     string name = string.Empty;

                    [ObservableProperty]
                     DateTime created_Dt =DateTime.Now;

                    [ObservableProperty]
                     DateTime modified_Dt =DateTime.Now;

                    [ObservableProperty]
                     DateTime infoDt =DateTime.Now;

                    [ObservableProperty]
                    string infoSubject = string.Empty;

                    [ObservableProperty]
                     string contractNr =string.Empty;

                    [ObservableProperty]
                     string customerNr =string.Empty;

                    [ObservableProperty]
                     DateTime startDate =DateTime.Now;

                    [ObservableProperty]
                     DateTime endDate =DateTime.Now;

                    [ObservableProperty]
                     DateTime cancelDeadline =DateTime.Now;

                    [ObservableProperty]
                    bool automatedContractExtension = false;

                    [ObservableProperty]
                     string notes = string.Empty;

                    [ObservableProperty]
                    bool remiderActive = false;
          }


}
