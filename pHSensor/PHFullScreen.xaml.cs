using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pHSensor
{
    /// <summary>
    /// Interaction logic for PHFullScreen.xaml
    /// </summary>
    public partial class PHFullScreen : Window
    {
        public PHFullScreen()
        {
            DataContext = Application.Current;
            InitializeComponent();
        }

        private void OnCloseCmdExecuted(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
