
using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartmoveapp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;

namespace Smartmoveapp.Views.Popups
{
          [XamlCompilation(XamlCompilationOptions.Compile)]
          public partial class CreateFolder : Popup
          {
                    public string NewFolderName { get => (string)GetValue(NewFolderNameProperty); set => SetValue(NewFolderNameProperty, value); }
                    public BindableProperty NewFolderNameProperty = BindableProperty.Create(nameof(NewFolderName), typeof(string), typeof(Entry));
                    public  List<Folder> Folders;
                    public CreateFolder( List<Folder> folders)
                    {
                              InitializeComponent();
                              Folders = folders;
                             
                    }
                    private void Cancel(object sender,EventArgs e) 
                    {
                              this.Dismiss(null);
                    }
                    private void Button_Clicked(object sender, EventArgs e)
                    {

                              Folders.Add(new Folder() { FolderName= NameEntry.Text});
                              this.Dismiss(Folders);

                    }
          }
}