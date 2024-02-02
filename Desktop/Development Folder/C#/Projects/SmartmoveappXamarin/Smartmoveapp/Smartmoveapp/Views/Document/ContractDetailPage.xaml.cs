
using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using Smartmoveapp.Views;
using Smartmoveapp.Views.Popups;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using XCalendar.Core.Models;
using XCalendar.Forms.Views;

namespace Smartmoveapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContractDetailPage : ContentPage
    {


        public DatePopUp DatePage;
        public ContractDetailPage()
        {
            InitializeComponent();

                    }
        readonly private  Folder Folder;
        
        public ContractDetailPage(SmartDocument _Document,Folder folder)
        {
            Folder = folder;
            BindingContext = _Document;
            InitializeComponent();
        }
        public async void ToTabPage(object sender, EventArgs args)
        {
            //Navigation.ShowPopup();

            await Navigation.PopAsync(true);
        }
        private void OpenDoc(object sender, EventArgs args)
        {
            

            var page = new DocView();
            Navigation.PushAsync(page, true);
        }
                    private async void AddTag(object sender, EventArgs e)
                    {
                              var viewModel = BindingContext as SmartDocument;
                              var tagpopup = await this.ShowPopupAsync(new TagAddPopup());
                              var tagtext = tagpopup as string;
                              Debug.WriteLine(tagtext);
                              if (tagtext != string.Empty)
                              {
                                        viewModel.Tags.Add(tagtext);
                              }
                    }
                    private void DateSelector(object sender, EventArgs args)
        {
                              
            new Smartmoveapp.Views.DatePicker();
   

        }
        public static DateTime DateSelect=DateTime.Now;
        public  async void SelectStartDate(object sender,EventArgs args)
        {
            DatePage = new DatePopUp(DateTime.Now, "start");
            this.ShowPopup(this.DatePage);

        }
        public void SelectEndDate(object sender, EventArgs args)
        {
            DatePage = new DatePopUp(DateTime.Now, "end");
            this.ShowPopup(DatePage);
        }
        public void SelectContractDuration(object sender, EventArgs args)
        {
        
        }
        public void Select(object sender, EventArgs args)
        {

        }
        public  async void Back(object sender,EventArgs args)
        {
            
            await Navigation.PopAsync(true);
        }

    }
    public class DatePopUp : Popup
    {

        public XCalendar.Forms.Views.CalendarView CalendarView = new XCalendar.Forms.Views.CalendarView
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            BackgroundColor = (Color)Application.Current.Resources["themecolora"]
            , IsVisible = true,


        };
        public Button ConfirmDate = new Button()
        {

            BackgroundColor = (Color)(Application.Current.Resources["themecolora"]),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            TextColor = (Color)(Application.Current.Resources["themecolorf"]),
            FontFamily = "Poppins",
            Text = "Confirm",
            TextTransform = TextTransform.None,
        };
                    string Op { get; set; } = string.Empty;
        public Calendar<CalendarDay> Calendar { get; set; } = new Calendar<CalendarDay>();
        public DatePopUp( DateTime time,string op) : base() 
        {
            Op = op;

            Calendar.NavigatedDate = time;
            this.CalendarView.BindingContext = Calendar;
            
           Calendar.AutoRows = true;
         
            this.CalendarView.SetBinding(CalendarView.DaysProperty, "Days");
            this.CalendarView.SetBinding(CalendarView.DaysOfWeekProperty, "DayNamesOrder");
           
            this.CalendarView.SetBinding(CalendarView.DaysProperty, "NavigatedDate");

            this.Content=new StackLayout
            {
                WidthRequest = 300,
                HeightRequest = 400,
                Orientation = StackOrientation.Vertical,
                BackgroundColor = (Color)Application.Current.Resources["themecolora"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children ={

                    CalendarView,
                    ConfirmDate
                }
            };
        this.CalendarView.NavigatedDate = time;
        this.CalendarView.Unfocused += CalendarView_Unfocused;
        this.ConfirmDate.Clicked += ConfirmDate_Clicked; 
        }

        private void ConfirmDate_Clicked(object sender, EventArgs e)
        {
           this.Dismiss(true);
        }

        private void CalendarView_Unfocused(object sender, FocusEventArgs e)
        {

        }

        public void Names() 
        {


        }
    }
 
}