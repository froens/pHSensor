using System.Collections.Generic;

namespace JetiAPI
{
    using System;
    using System.Text;

    public class Measurement
    {
        public DateTime TimeStamp { get; private set; }
        public int IntegrationTime { get; private set; }
        public int Average { get; private set; }
        public string CommandString { get; private set; }
        public List<LightMeasurement>  Measures { get; private set; }

        public Measurement(int integrationTime, int average, List<LightMeasurement> measures, DateTime timeStamp, string cmd)
        {
            CommandString = cmd;
            TimeStamp = timeStamp;
            Measures = measures;
            Average = average;
            IntegrationTime = integrationTime;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("------------ Summary ---------");
            sb.AppendLine(String.Format("Timestamp: {0}", TimeStamp));
            sb.AppendLine(String.Format("Integration time: {0}", IntegrationTime));
            sb.AppendLine(String.Format("Average: {0}", Average));
            sb.AppendLine(String.Format("Command: {0}", CommandString));

            sb.AppendLine("------------ Measurements ---------");
            foreach (var lightMeasurement in Measures)
            {
                sb.AppendLine(String.Format("{0}\t{1}", lightMeasurement.WaveLength, lightMeasurement.Intensity));
            }

            return sb.ToString();
        }
    }
}
