using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using JetiAPI;
using pHSensor.CurveModels;

namespace pHSensor
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, INotifyPropertyChanged
    {
        private ObservableCollection<DataPoint> dataPoints = new ObservableCollection<DataPoint>();
        public ObservableCollection<DataPoint> DataPoints
        {
            get { return this.dataPoints; }
            set { this.dataPoints = value; }
        }

        private double ph;
        public double PH
        {
            get
            {
                return ph;
            }
            set
            {
                ph = value;
                OnPropertyChanged();
            }
        }

        private Measurement darkMeasurement;
        public Measurement DarkMeasurement
        {
            get
            {
                return darkMeasurement;
            }
            set
            {
                darkMeasurement = value;

                darkMeasurements.Clear();
                foreach (var dm in darkMeasurement.Measures)
                {
                    darkMeasurements.Add(dm);
                }
            }
        }

        private ObservableCollection<LightMeasurement> darkMeasurements = new ObservableCollection<LightMeasurement>();
        public ObservableCollection<LightMeasurement> DarkMeasurements
        {
            get { return this.darkMeasurements; }
            set { this.darkMeasurements = value; }
        }

        private ObservableCollection<LightMeasurement> measurements = new ObservableCollection<LightMeasurement>();
        public ObservableCollection<LightMeasurement> Measurements
        {
            get { return this.measurements; }
            set { this.measurements = value; }
        }

        public List<PHCalculation> HistoricCalculations = new List<PHCalculation>();

        private readonly ObservableCollection<LightMeasurement> aMeasures = new ObservableCollection<LightMeasurement>();
        public ObservableCollection<LightMeasurement> AMeasures
        {
            get { return this.aMeasures; }
            //set { this.AMeasures = value; }
        }

        private readonly ObservableCollection<LightMeasurement> bMeasures = new ObservableCollection<LightMeasurement>();
        public ObservableCollection<LightMeasurement> BMeasures
        {
            get { return this.bMeasures; }
        }

        private Curve curve = new BoltzmannCurve();
        public Curve Curve
        {
            get { return this.curve; }
            set { this.curve = value; }
        }

        void AppStartup(object sender, StartupEventArgs args)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
