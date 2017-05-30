using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Kniaz.LMA;

namespace pHSensor.CurveModels
{
    public abstract class Curve : LMAFunction
    {
        public ObservableCollection<Parameter> Parameters
        {
            get;
            set;
        }

        public abstract string Name
        {
            get;
            set;
        }

        public double GetY(double x)
        {
            return this.GetY(x, Parameters.Select(b => b.Value).ToArray());
        }
    }
}
