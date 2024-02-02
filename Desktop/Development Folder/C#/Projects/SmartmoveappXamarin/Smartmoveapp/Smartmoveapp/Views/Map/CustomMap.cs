using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Maps;

namespace Smartmoveapp.Views
{
          public class CustomMap : Map,INotifyPropertyChanged
          {
                    public ObservableCollection<CustomPin> CustomPins { get; set; }=new ObservableCollection<CustomPin>();

                    public event PropertyChangedEventHandler PropertyChanged;
                    public CustomMap() 
                    {
                              CustomPins.CollectionChanged += CustomPins_CollectionChanged;
                    }

                    private void CustomPins_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                    {
                             this.PropertyChanged?.Invoke(CustomPins,new PropertyChangedEventArgs(nameof(CustomPins)));
                    }
          }
         
}
