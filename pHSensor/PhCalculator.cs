namespace pHSensor
{
    using System;
    using System.Linq;

    using JetiAPI;

    using pHSensor.CurveModels;

    public class PhCalculator
    {
        private readonly Curve curve;

        public PhCalculator(Curve curve)
        {
            this.curve = curve;
        }

        public PHCalculation Calculate(Measurement measuresment, Measurement darkMeasurement, double startA, double endA, double startB, double endB)
        {
            var aArea = measuresment.Measures.Where(x => startA <= x.WaveLength && x.WaveLength <= endA).ToList();
            var sumA = aArea.Sum(x => x.Intensity);

            var bArea = measuresment.Measures.Where(x => startB <= x.WaveLength && x.WaveLength <= endB).ToList();
            var sumB = bArea.Sum(x => x.Intensity);

            if (darkMeasurement != null)
            {
                var darkA = darkMeasurement.Measures.Where(x => startA <= x.WaveLength && x.WaveLength <= endA).Sum(x => x.Intensity);
                var darkB = darkMeasurement.Measures.Where(x => startB <= x.WaveLength && x.WaveLength <= endB).Sum(x => x.Intensity);
                sumA = sumA - darkA;
                sumB = sumB - darkB;
            }

            var signal = 0d;
            var pH = Double.NaN;
            if (sumB > 0)
            {
                signal = (double)sumA / (double)sumB;
                pH = curve.GetY(signal);
            }

            return new PHCalculation(measuresment, startA, endA, startB, endB, signal, pH, curve);
        }
    }
}
