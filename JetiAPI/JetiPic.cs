using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
using JetiAPI.CommandStrings;

namespace JetiAPI
{
    public class JetiPic
    {
        private const string VERSA_PIC_DEVICE_ID = "JETI_PIC_VERSA";
        private readonly SerialPort _serialPort;
        private readonly List<int> _baudRates = new List<int>() { 38400, 115200, 921600 };

        public JetiPic()
        {
            _serialPort = SearchSerialPorts();
        }

        public string Execute(JetiCommand cmd)
        {
            _serialPort.Write(String.Format("{0}\r", cmd.ToString()));
            var sb = new StringBuilder();
            Thread.Sleep(2000);
            while (_serialPort.BytesToRead > 0)
            {
                sb.Append(_serialPort.ReadExisting());
                Thread.Sleep(200);
            }
            return sb.ToString();
        }

        public List<Measurement> Measure(JetiAPI.JetiCommands.Measure measureCommand)
        {
            var str = Execute(measureCommand);
            str = str.TrimStart(new char[] { (char)6, (char)7 });
            str = str.Replace(" ", "");
            var rows = str.Split('\r');

            var measurements = new List<Measurement>();
            var parseErrors = new List<string>();
            
            foreach (var m in rows)
            {
                try
                {
                    var tokens = m.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    var i = int.Parse(tokens[1]);
                    var w = double.Parse(tokens[0]);
                    measurements.Add(new Measurement() { WaveLength = w, Intensity = i });
                }
                catch (Exception)
                {
                    parseErrors.Add(m);
                }
            }
            return measurements;
        }

        private SerialPort SearchSerialPorts()
        {
            foreach(var pn in SerialPort.GetPortNames())
            {
                foreach (var br in _baudRates)
                {
                    var found = false;
                    var sp = new SerialPort(pn, br) { ReadTimeout = 500, WriteTimeout = 500 };
                    try
                    {
                        sp.Open();
                        sp.WriteLine(String.Format("*{0}?\r", Commands.DeviceId));
                        Thread.Sleep(20);
                        if (sp.ReadExisting().Contains(VERSA_PIC_DEVICE_ID))
                        {
                            found = true;
                            return sp;
                        }
                    }
                    catch (Exception) { }
                    finally
                    {
                        if (!found)
                        {
                            sp.Close();
                        }
                    }
                }
            }
            return null;
        }
    }
}
