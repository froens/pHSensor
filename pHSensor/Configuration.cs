using System.Collections.Generic;

namespace pHSensor
{
    public class Configuration
    {
        public int Interval { get; set; }
        public double Average { get; set; }
        public int IntegrationTime { get; set; }
        
        public double AStart { get; set; }
        public double AEnd { get; set; }
        public double BStart { get; set; }
        public double BEnd { get; set; }

        public List<Parameter> Parameters { get; set; }
    }
}
