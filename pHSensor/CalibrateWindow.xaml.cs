using System;
using System.Linq;
using System.Windows;
using DotNetMatrix;
using Net.Kniaz.LMA;
using pHSensor.CurveModels;

namespace pHSensor
{
    /// <summary>
	/// Interaction logic for Calibrate.xaml
	/// </summary>
	public partial class CalibrateWindow : Window
	{
    	public CalibrateWindow()
    	{
    	    this.InitializeComponent();
    	}

        private void UpdateLine()
        {
            Curve f = ((App)Application.Current).Curve;
            line.ItemsSource = Enumerable.Range(0, 1000).Select((a => new DataPoint() { Signal = a * 0.01, pH = f.GetY(a * 0.01) }));
        }

        private void CalibrateClick(object sender, RoutedEventArgs e)
        {
            //Retrieve datapoints
            var dps = ((App)Application.Current).DataPoints;
            var dataPoints = new double[][] { dps.Select(a => a.Signal).ToArray(), dps.Select(b => b.pH).ToArray() };

            //Retrieve chosen Curve
            var f = ((App)Application.Current).Curve;

            //Instantiate algorithm
            var algorithm = new LMA(f, f.Parameters.Select(a => a.Value).ToArray(),
                dataPoints, null, new GeneralMatrix(f.Parameters.Count, f.Parameters.Count), 1d - 30, 100);

            algorithm.Fit();
            
            //Copy fitted parameter values to Curve
            for (int i = 0; i < algorithm.Parameters.Count(); i++)
            {
                f.Parameters[i].Value = algorithm.Parameters[i];
            }
            this.UpdateLine();
            chi2.Content = String.Format("{0:N5}", algorithm.Chi2);
        }

        private void CollectionViewSourceFilter(object sender, System.Windows.Data.FilterEventArgs e)
        {
            var kvp = (Parameter)e.Item;
            if (!String.IsNullOrEmpty(kvp.Name))
            {
                e.Accepted = true;
            }
        }

        private void TblDataPointsCurrentCellChanged(object sender, EventArgs e)
        {
            PltVisual.InvalidatePlot(true);
        }
	}
}