using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.ViewModels
{
          public partial class AgentViewModel:ObservableObject
          {

                    [ObservableProperty]
                    Agency agent=new Agency();
                    [ObservableProperty]
                    List<SmartDocument> agentDocuments = new List<SmartDocument>();
                    [ObservableProperty]
                    [NotifyPropertyChangedFor(nameof(VisibilityIcon))]
                    bool isSensitiveVIsible = false;
                    public string VisibilityIcon => !IsSensitiveVIsible ? "visibility" : "visibility_off";
                    
          }
}
