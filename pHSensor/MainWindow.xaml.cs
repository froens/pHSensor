namespace pHSensor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    using JetiAPI;

    using Application = System.Windows.Application;
    using MessageBox = System.Windows.MessageBox;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //private static readonly BaseSpectrometer Spektrometer = new JetiSpectrometer();
        private static readonly BaseSpectrometer Spektrometer = new FakeSpectrometer();

        private bool isRunning;
        public bool IsRunning
        {
            set
            {
                isRunning = value;
                NotifyPropertyChanged();
            }
            get
            {
                return isRunning;
            }
        }

        #region handlers

        private void ShowLoading(string msg = null)
        {
            LblLoading.Content = msg ?? "Loading";
            LoadingBar.Visibility = Visibility.Visible;
        }

        private void HideLoading()
        {
            LoadingBar.Visibility = Visibility.Hidden;
        }

        private void BtnLampeClick(object sender, RoutedEventArgs e)
        {
            var bckWorker = new BackgroundWorker();
            bckWorker.DoWork += (o, args) => Spektrometer.SwitchLamp();
            bckWorker.RunWorkerCompleted += (o, args) => HideLoading();

            this.ShowLoading("Switching lamp");
            bckWorker.RunWorkerAsync();
        }

        private async void DarkMeasurement(object sender, RoutedEventArgs e)
        {
            double aStart, aEnd;
            double bStart, bEnd;
            int tint, avg, interval;

            var isValid = TryGetInput(out tint, out avg, out aStart, out aEnd, out bStart, out bEnd, out interval);
            if (!isValid) return;

            var measCmd = new JetiAPI.JetiCommands.Measure.Dark { Average = avg, Tint = tint };
            var darkMeasurement = await Spektrometer.MeasureAsync(measCmd);

            var app = ((App)Application.Current);
            app.DarkMeasurement = darkMeasurement;

            Plot.InvalidatePlot(true);
        }

        private void ExportClk(object sender, RoutedEventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var app = ((App)Application.Current);
                var i = 0;
                foreach (var calc in app.HistoricCalculations.OrderBy(x => x.MeasurementData.TimeStamp))
                {
                    var f = File.Open(String.Format("{0}\\{1}.log", folderBrowserDialog.SelectedPath, i), FileMode.OpenOrCreate);
                    var sb = new StringBuilder();
                    sb.AppendLine(calc.ToString());
                    sb.AppendLine(calc.MeasurementData.ToString());
                    var output = Encoding.UTF8.GetBytes(sb.ToString());
                    f.Write(output, 0, output.Length);
                    f.Flush();
                    f.Close();
                    i++;
                }
            }
        }

        private async void StartClick(object sender, RoutedEventArgs e)
        {
            var app = ((App)Application.Current);
            var phCalculator = new PhCalculator(app.Curve);

            if (IsRunning)
            {
                BtnStart.Content = "Start";
                IsRunning = false;
                return;
            }
            
            BtnStart.Content = "Stop";
            IsRunning = true;

            double aStart, aEnd;
            double bStart, bEnd;
            int tint, avg, interval;

            #region Validation

            var isValid = TryGetInput(out tint, out avg, out aStart, out aEnd, out bStart, out bEnd, out interval);

            if (!isValid) return;
            
            #endregion

            var measCmd = new JetiAPI.JetiCommands.Measure { Average = avg, Tint = tint };
            while (isRunning)
            {
                
                var measurement = await Spektrometer.MeasureAsync(measCmd);
                if (measurement != null && isRunning)
                {
                    var calculation = phCalculator.Calculate(measurement, app.DarkMeasurement, aStart, aEnd, bStart, bEnd);
                    app.PH = calculation.PH;
                    app.HistoricCalculations.Add(calculation);
                    
                    LblOutput.Content = calculation.ToString();

                    var measures = measurement.Measures;

                    app.AMeasures.Clear();
                    var aRange = measures.Where(x => x.WaveLength >= aStart && x.WaveLength <= aEnd);
                    foreach (var i in aRange)
                    {
                        app.AMeasures.Add(i);
                    }

                    app.BMeasures.Clear();
                    var bRange = measures.Where(x => x.WaveLength >= bStart && x.WaveLength <= bEnd);
                    foreach (var i in bRange)
                    {
                        app.BMeasures.Add(i);
                    }

                    app.Measurements.Clear();
                    foreach (var i in measures)
                    {
                        app.Measurements.Add(i);
                    }
                }
                Plot.InvalidatePlot(true);
                await Task.Delay(interval * 1000);
            }
        }

        private bool TryGetInput(out int tint, out int avg, out double aStart, out double aEnd, out double bStart, out double bEnd, out int interval)
        {
            bool isValid = true;

            if (!int.TryParse(TxtTint.Text, out tint))
            {
                MessageBox.Show(this, "Integration time is invalid");
                isValid = false;
            }
            if (!int.TryParse(TxtAv.Text, out avg))
            {
                MessageBox.Show(this, "Average is invalid");
                isValid = false;
            }
            if (!double.TryParse(TxtAStart.Text, out aStart))
            {
                MessageBox.Show(this, "A-start is invalid");
                isValid = false;
            }
            if (!double.TryParse(TxtAEnd.Text, out aEnd))
            {
                MessageBox.Show(this, "A-end is invalid");
                isValid = false;
            }
            if (!double.TryParse(TxtBStart.Text, out bStart))
            {
                MessageBox.Show(this, "B-start is invalid");
                isValid = false;
            }
            if (!double.TryParse(TxtBEnd.Text, out bEnd))
            {
                MessageBox.Show(this, "B-end is invalid");
                isValid = false;
            }
            if (!int.TryParse(TxtInterval.Text, out interval))
            {
                MessageBox.Show(this, "Interval is invalid");
                isValid = false;
            }

            if (aEnd <= aStart)
            {
                MessageBox.Show(this, "A-start must be smaller than A-end");
                isValid = false;
            }
            if (bEnd <= bStart)
            {
                MessageBox.Show(this, "B-start must be smaller than B-end");
                isValid = false;
            }

            return isValid;
        }
            
        private void BtnCalibrateClick(object sender, RoutedEventArgs e)
        {
            var cw = new CalibrateWindow {Owner = this};
            cw.ShowDialog();
        }

        private void ShowFullScreen(object sender, RoutedEventArgs e)
        {
            new PHFullScreen().Show();
        }

        private void SaveConfigClick(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                DefaultExt = "xml",
                AddExtension = true,
                Filter = @"XML-files (*.xml)|*.xml",
            };
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                double aStart, aEnd;
                double bStart, bEnd;
                int tint, avg, interval;

                var isValid = TryGetInput(out tint, out avg, out aStart, out aEnd, out bStart, out bEnd, out interval);
                
                var app = ((App)Application.Current);
                using (var fileStream = sfd.OpenFile())
                {
                    var conf = new Configuration()
                    {
                        AStart = aStart,
                        AEnd = aEnd,
                        BStart = bStart,
                        BEnd = bEnd,
                        Average = avg,
                        IntegrationTime = tint,
                        Interval = interval,
                        Parameters = app.Curve.Parameters.ToList()
                    };
                    var serializer = new XmlSerializer(typeof(Configuration));
                    serializer.Serialize(fileStream, conf);
                }
            }
        }

        private void OpenConfigClick(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                DefaultExt = "xml",
                AddExtension = true,
                Filter = @"XML-files (*.xml)|*.xml",
            };

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fileStream = ofd.OpenFile();
                var serializer = new XmlSerializer(typeof(Configuration));
                var configuration = (Configuration)serializer.Deserialize(fileStream);

                TxtAStart.Text = configuration.AStart.ToString();
                TxtAEnd.Text = configuration.AEnd.ToString();
                TxtBStart.Text = configuration.BStart.ToString();
                TxtBEnd.Text = configuration.BEnd.ToString();

                TxtTint.Text = configuration.IntegrationTime.ToString();
                TxtAv.Text = configuration.Average.ToString();
                TxtInterval.Text = configuration.Interval.ToString();

                var app = ((App)Application.Current);
                app.Curve.Parameters.Clear();
                foreach (var p in configuration.Parameters)
                {
                    app.Curve.Parameters.Add(p);
                }
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}