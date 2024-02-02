using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.Widget;
using Smartmoveapp;
using Smartmoveapp.Droid;
using Smartmoveapp.Models;
using Smartmoveapp.ViewModels;
using Smartmoveapp.Views;
using Xamarin.CommunityToolkit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using XF.Material.Forms.Resources.Typography;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace Smartmoveapp.Droid
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        ObservableCollection<CustomPin> customPins;

        public CustomMapRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            NativeMap.InfoWindowClick += OnInfoWindowClick;
            NativeMap.SetInfoWindowAdapter(this);
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            //marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin));
            return marker;
        }

        void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var customPin = GetCustomPin(e.Marker);
            if (customPin == null)
            {
                throw new Exception("Custom pin not found");
            }

            if (!string.IsNullOrWhiteSpace(customPin.Url))
            {
                var url = Android.Net.Uri.Parse(customPin.Url);
                var intent = new Intent(Intent.ActionView, url);
                intent.AddFlags(ActivityFlags.NewTask);
                Android.App.Application.Context.StartActivity(intent);
            }
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;

                var customPin = GetCustomPin(marker);
                if (customPin == null)
                {
                    throw new Exception("Custom pin not found");
                }

               /* if (customPin.Name.Equals("Xamarin"))
                {
                    view = inflater.Inflate(Resource.Layout.XamarinMapInfoWindow, null);
                }
                else
                {
                    view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
                }*/
                view = inflater.Inflate(Resource.Layout.XamarinMapInfoWindow, null);
         
                var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
                var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);
                var rating = view.FindViewById<TextView>(Resource.Id.RatingCount);
                rating.Text =Convert.ToString(customPin.Rating);
               
                var ratingbar= view.FindViewById<RatingBar>(Resource.Id.ratingBar);
                ratingbar.Rating = (float)customPin.Rating;
                var ratingcount = view.FindViewById<TextView>(Resource.Id.Ratings);
                ratingcount.Text = Convert.ToString(customPin.RatingCount);

                //Action Buttons
                var directionbutton = view.FindViewById<Android.Widget.Button>(Resource.Id.directions);
                var bookmarkbutton = view.FindViewById<Android.Widget.Button>(Resource.Id.bookmark);
               
                directionbutton.Text = "directions";
                directionbutton.Typeface =MainActivity.materialfont;

                bookmarkbutton.Text = "bookmark";
                bookmarkbutton.Typeface = MainActivity.materialfont;

                infoTitle.Typeface = MainActivity.poppinsfont;
                infoSubtitle.Typeface = MainActivity.poppinsfont;
                if (infoTitle != null)
                {
                    infoTitle.Text = marker.Title;
                }
                if (infoSubtitle != null)
                {
                    infoSubtitle.Text = marker.Snippet;
                }
                return view;
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        CustomPin GetCustomPin(Marker annotation)
        {
            
            var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
                            
            foreach (var pin in customPins)
            {
                
                if (pin.Position == position)
                {
                    return pin;
                }
            }
            return null;
        }
    }
}
