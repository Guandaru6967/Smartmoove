using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Smartmoveapp.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.CommunityToolkit.Extensions;
using Smartmoveapp.Models;
using System.Net.NetworkInformation;
using System.Collections.ObjectModel;

namespace Smartmoveapp.Views
{
    public partial class MapPage : ContentPage
    {
                    readonly private ObservableCollection<Agency> Agencies;
                    public MapPage(Position position)
        {
            InitializeComponent();
            MapSpan span = new MapSpan(position, 0.01, 0.01);
            
            map.MoveToRegion(span);
        }
                    public MapPage(ref ObservableCollection<Agency> agencies,Position position)
                    {
                              InitializeComponent();
                              MapSpan span = new MapSpan(position, 0.01, 0.01);
                              map.MoveToRegion(span);
                              Agencies=agencies;
                    }
                    private async void Button_Clicked(object sender, EventArgs e)
        {

             this.ShowPopup(new PopUpPage());
        }
        protected override void OnAppearing()
        {
      
            base.OnAppearing();
            //map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(agency.Item1, agency.Item2), Distance.FromMiles(30)));
            
            CustomMap customMap = new CustomMap
            {
                MapType = MapType.Street
            };
            customMap.CustomPins = new ObservableCollection<CustomPin>();
            foreach (var agency in Agencies)
            {
                CustomPin agencypin = new CustomPin
                {
                    Type = PinType.Place,
                    Position = new Position(agency.Position.Item1,agency.Position.Item2),
                    Label = agency.Name,
                    Address =agency.Address,
                    Name = "Xamarin",
                  
            };
                customMap.Pins.Add(agencypin);
                customMap.CustomPins.Add(agencypin);
            }
            CustomPin pin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(37.79752, -122.40183),
                Label = "TestLocation",
                Address = "394 Pacific Ave, San Francisco CA",
                Name = "Xamarin",

            };
            customMap.Pins.Add(pin);
            customMap.CustomPins.Add(pin);


            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMiles(1.0)));

            Content = customMap;
        }
    }
}