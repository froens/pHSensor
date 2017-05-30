namespace pHSensor
{
    using System;
    using System.Text;

    using JetiAPI;

    using pHSensor.CurveModels;

    public class PHCalculation
    {
        public PHCalculation(Measurement measurementData, double aStart, double aEnd, double bStart, double bEnd, double signal, double ph, Curve curve)
        {
            PH = ph;
            Signal = signal;
            BEnd = bEnd;
            BStart = bStart;
            AEnd = aEnd;
            AStart = aStart;
            MeasurementData = measurementData;
            Curve = curve;
        }

        public Measurement MeasurementData { get; private set; }
        public double AStart { get; private set; }
        public double AEnd { get; private set; }
        public double BStart { get; private set; }
        public double BEnd { get; private set; }

        public double Signal { get; private set; }
        public double PH { get; private set; }

        public Curve Curve { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("------------ pH-Calculation ---------");
            sb.AppendLine(String.Format("pH-value: {0}", PH));
            sb.AppendLine(String.Format("Signal: {0}", Signal));
            
            sb.AppendLine(String.Format("A-Start: {0}", AStart));
            sb.AppendLine(String.Format("A-End: {0}", AEnd));
            sb.AppendLine(String.Format("B-Start: {0}", BStart));
            sb.AppendLine(String.Format("B-End: {0}", BEnd));


            sb.AppendLine("------------ Curve ---------");
            foreach (var parameter in Curve.Parameters)
            {
                sb.AppendLine(String.Format("{0}: {1}", parameter.Name, parameter.Value));
            }
            return sb.ToString();
        }
    }
}

