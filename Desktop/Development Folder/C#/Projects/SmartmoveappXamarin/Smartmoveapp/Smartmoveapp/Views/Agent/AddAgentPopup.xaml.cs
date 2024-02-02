using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views.Agent
{
          [XamlCompilation(XamlCompilationOptions.Compile)]
          public partial class AddAgentPopup : Popup
          {
                    public AddAgentPopup(List<Agency> agencies)
                    {
                              InitializeComponent();
                              BindingContext = agencies;
                    }

                    private void AgentSelectionChanged(object sender, SelectionChangedEventArgs e)
                    {
                              var agent = e.CurrentSelection.FirstOrDefault() as Agency;
                              var collection = sender as CollectionView;
                              collection.SelectedItem = null;
                              collection.SelectedItems.Clear();
                              this.Dismiss(agent);
                    }
          }
}