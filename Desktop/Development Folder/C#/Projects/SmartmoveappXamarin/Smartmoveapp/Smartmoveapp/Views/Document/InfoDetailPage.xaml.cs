
using Smartmoveapp.Models;
using Smartmoveapp.Views.Popups;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Chips;
using Xamarin.Forms.Xaml;

namespace Smartmoveapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoDetailPage : ContentPage
    {
        public InfoDetailPage()
        {
            InitializeComponent();
        }
        public InfoDetailPage(SmartDocument document)
        {
                              BindingContext = document;
            InitializeComponent();
        }
                    private void RemoveTag(object sender,EventArgs  e) 
                    {

                              var button = sender as ImageButton;
                              var item = button.BindingContext as string;
                              var viewModel = BindingContext as SmartDocument;
                              viewModel.Tags.Remove(item);

                    }
                    private async void AddTag(object sender, EventArgs e)
                    {
                              var viewModel = BindingContext as SmartDocument;
                              var tagpopup = await this.ShowPopupAsync(new TagAddPopup());
                              var tagtext = tagpopup as string;
                              Debug.WriteLine(tagtext);
                              Debug.WriteLine(100);
                              if (tagtext != string.Empty)
                              {
                                        viewModel.Tags.Add(tagtext);
                                        Debug.WriteLine(500);
                              }
                    }
                    private void OpenDoc(object sender, EventArgs args)
        {


            var page = new DocView();
            Navigation.PushAsync(page, true);
        }
        public async void ToTabPage(object sender, EventArgs args)
        {
            
           await  Navigation.PopAsync(true);
        }
    }
}