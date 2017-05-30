using System;
using System.Collections.Generic;

namespace PerformanceAnalysis
{
    using System.Diagnostics;

    using JetiAPI;

    using Measure = JetiAPI.JetiCommands.Measure;

    class Program
    {
        static void Main(string[] args)
        {
            var jetiSpektrometer = new JetiSpectrometer();
            var measurements = new List<Measurement>();
            var sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < 100; i++)
            {
                measurements.Add(jetiSpektrometer.Measure(new Measure() { Average = 7, Format = 4, Tint = 100 }));
            }
            sw.Stop();

            Console.WriteLine(sw.Elapsed);
        }
    }
}
