using System;

namespace JetiAPI
{
    public class LightMeasurement
    {
        public double WaveLength { get; set; }
        public int Intensity { get; set; }

        public int Zero 
        { 
            get
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}\t {1}", WaveLength, Intensity);
        }
    }
}
