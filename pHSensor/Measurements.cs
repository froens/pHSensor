using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using JetiAPI;

namespace pHSensor
{
    public class Measurements : ObservableCollection<LightMeasurement>, INotifyPropertyChanged
    {
        //public measures()
        //{
        //    this.OnCollectionChanged += new PropertyChangedEventHandler();
        //}


        //public event PropertyChangedEventHandler PropertyChanged;
        //private void NotifyPropertyChanged(String propertyName)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (null != handler)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}



        //public bool IsEmpty
        //{
        //    get { return this.Count < 1; }
        //}
    }
}
