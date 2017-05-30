using System.Threading;
using JetiAPI;

namespace UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Measure = JetiAPI.JetiCommands.Measure;

    [TestClass]
    public class TestJetiSpektrometer
    {
        private readonly BaseSpectrometer jetiSpektrometer;

        public TestJetiSpektrometer()
        {
#if DEBUG
            this.jetiSpektrometer = new FakeSpectrometer();
#else
            this.jetiSpektrometer = new JetiSpectrometer();
#endif
        }

        [TestMethod]
        public void TestMeasure()
        {
            var m = this.jetiSpektrometer.Measure(new Measure {Average = 7, Format = 7, Tint = 100});
            Assert.IsTrue(m.Measures.Count > 0);
        }

        [TestMethod]
        public void TestMultipleMeasure()
        {
            var measurements = new List<Tuple<int, string, long>>();
            
            for (int i = 0; i < 10; i++)
            {
                var timeout = 1000 + 100 * i;
                //jetiSpektrometer.serialPort.ReadTimeout = timeout;
                try
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    var m = jetiSpektrometer.Measure(new Measure { Average = 7, Format = 7, Tint = 100 });
                    sw.Stop();
                    measurements.Add(new Tuple<int, string, long>(timeout, m.Measures.Count.ToString(), sw.ElapsedMilliseconds));
                    
                }
                catch (Exception ex)
                {
                    measurements.Add(new Tuple<int, string, long>(timeout, ex.InnerException.Message, -1));
                }
            }
            

            foreach (var t in measurements.OrderBy(x => x.Item1))
            {
                Console.WriteLine("{0} : {1} : {2}", t.Item1, t.Item2, t.Item3);
            }

            Console.WriteLine(jetiSpektrometer.ReadLog());
        }

        //[Test]
        //public void TestThreshold()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        var measurements = new List<Measurement>();
        //        var sw = new Stopwatch();

        //        sw.Start();
        //        for (int i = 0; i < 100; i++)
        //        {
        //            measurements.Add(this.jetiSpektrometer.LightMeasurement(new LightMeasurement() { Average = 7, Format = 4, Tint = 100 }));
        //        }
        //        sw.Stop();

        //        Console.WriteLine(sw.Elapsed);
        //    }
        //}

        [TestMethod]
        public void TestLamp()
        {
            this.jetiSpektrometer.SwitchLamp();
            Thread.Sleep(2000);
            this.jetiSpektrometer.SwitchLamp();
        }

        [TestMethod]
        public void TestExecuteMeasureDark()
        {
            var s = this.jetiSpektrometer.Execute(new Measure.Dark { Average = 7, Format = 7, Tint = 100 });
            Assert.IsTrue(s.Length > 10);
        }

    }
}
