using System.ComponentModel;

namespace pHSensor
{
    public class Parameter : INotifyPropertyChanged
    {
        private string m_name;
        public string Name
        {
            get { return m_name; }
            set 
            {
                m_name = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }

        private double m_value;
        public double Value
        {
            get { return m_value; }
            set
            {
                m_value = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Value"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
