using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace pHSensor.CurveModels
{
    /// <summary>
    /// Implements Gauss Bell Shape function
    /// </summary>
    public class BoltzmannCurve : Curve
    {
        
        public BoltzmannCurve()
        {
            Parameters = new ObservableCollection<Parameter>() {
                new Parameter() { Name = "Slope", Value = 0.2 }, 
                new Parameter() { Name = "V50", Value = 5 }
            };
        }

        private static int Bottom = 0;
        private static int Top = 14;

        /// <summary>
        /// Returns Gaussian values
        /// </summary>
        /// <param name="x">x value</param>
        /// <param name="a">parameters</param>
        /// <returns></returns>
        public override double GetY(double x, double[] a)
        {
            if (a.Length != 2)
                throw new ArgumentException("Invalid number of parameters for Boltzmann: 2 parameters are required");

            return Bottom + ((Top - Bottom) / (1 + Math.Exp((a[1] - x) / a[0])));
            
        }

        /// <summary>
        /// Derivative value
        /// </summary>
        /// <param name="x">x value</param>
        /// <param name="a">vector of parameters</param>
        /// <param name="parameterIndex"></param>
        /// <returns></returns>
        public override double GetPartialDerivative(double x, double[] a, int parameterIndex)
        {
            switch (parameterIndex)
            {
                case 0:
                    return (Math.Exp((a[1] - x) / a[0]) * (-Bottom + Top) * (a[1] - x)) / (Math.Pow(1 + Math.Exp((a[1] - x) / a[0]), 2) * Math.Pow(a[0], 2));
                case 1:
                    return (Math.Exp((a[1] + x) / a[0]) * (Bottom - Top)) / (Math.Pow((Math.Exp(a[1] / a[0]) + Math.Exp(x / a[0])), 2) * a[0]);
                default:
                    throw new ArgumentException("ParameterIndex is wrong");
            }
        }

        public override string Name
        {
            get { return "Boltzmann"; }
            set { }
        }
    }
	
}
