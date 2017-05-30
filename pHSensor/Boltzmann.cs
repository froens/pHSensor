using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pHSensor
{
    public class Boltzmann : NonlinearCurve
    {
        private int Bottom = 0;
        private int Top = 14;

        // Call the base constructor with the number of
        // parameters.
        public Boltzmann() : base(2)
        {
            // It is convenient to set common starting values
            // for the curve parameters in the constructor:

            //Slope
            this.Parameters[0] = 0.3;

            //V50
            this.Parameters[1] = 5;
        }

        // The ValueAt method evaluates the function:
        override public double ValueAt(double x)
        {

            return Bottom + ((Top - Bottom) / (1 + Math.Exp((Parameters[1]-x)/Parameters[0])));
        }

        // The SlopeAt method evaluates the derivative:
        override public double SlopeAt(double x)
        {
            return (Math.Exp((Parameters[1] + x) / Parameters[0])*(-Bottom + Top)) / (Math.Pow((Math.Exp(Parameters[1] / Parameters[0]) + Math.Exp(x / Parameters[0])),2) * Parameters[0]);
        }

        // The FillPartialDerivatives evaluates the partial derivatives
        // with respect to the curve parameters, and returns
        // the result in a vector. If you don't supply this method, 
        // a numerical approximation is used.
        /*override public void FillPartialDerivatives(double x, DenseVector f)
        {
            double exp = Math.Exp(Parameters[1] / (x + Parameters[2]));
            f[0] = exp;
            f[1] = Parameters[0] * exp / (x + Parameters[2]);
            f[2] = -Parameters[0] * Parameters[1] * exp / Math.Pow(x + Parameters[2], 2);
        }*/
    }
}
