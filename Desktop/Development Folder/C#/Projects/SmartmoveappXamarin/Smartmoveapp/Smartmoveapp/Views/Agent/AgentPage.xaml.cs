using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views.Agent
{
          public class DocumentSelector : DataTemplateSelector 
          {
                    public DataTemplate InvoiceTemplate { get; set; }
                    public DataTemplate ContractTemplate{ get; set; }
                    public DataTemplate InformationTemplate { get; set; }
                   
                    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
                    {
                              var document = item as SmartDocument;
                              switch (document.DocType) 
                              {
                                        case "INFO":
                                                  return InformationTemplate;
                                        case "CONTRACT":
                                                  return ContractTemplate;
                                        case "INVOICE":
                                                  return InvoiceTemplate;
                                        default:
                                                  return InformationTemplate;
                              }
                    }
          }
          [XamlCompilation(XamlCompilationOptions.Compile)]
          public partial class AgentPage : ContentPage
          {
                    public AgentPage(Agency agent,List<SmartDocument> doclisting)
                    {
                              InitializeComponent();
                              BindingContext=new AgentViewModel { Agent = agent , AgentDocuments = doclisting};
                    }
                    private void ToggleVisibililty(object sender, EventArgs e) 
                    {
                              var viewModel=BindingContext as AgentViewModel;
                              viewModel.IsSensitiveVIsible = !viewModel.IsSensitiveVIsible;
                    }
          }
}