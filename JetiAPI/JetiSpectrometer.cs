using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.IO.Ports;
using JetiAPI.CommandStrings;
using Control = JetiAPI.JetiCommands.Control;

namespace JetiAPI
{
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class JetiSpectrometer : BaseSpectrometer
    {
        private const string VERSA_PIC_DEVICE_ID = "JETI_PIC_VERSA";
        public readonly SerialPort serialPort;
        private readonly List<int> baudRates = new List<int> { 38400, 115200, 921600 };
        
        private const int BUFF_SIZE = 1024;
        private const int STREAM_TIMEOUT = 2000;
        private readonly Queue<char> q = new Queue<char>();

        public JetiSpectrometer()
        {
            serialPort = SearchSerialPorts();
        }

        public override async Task<string> ExecuteAsync(JetiCommand cmd)
        {
            try
            {
                log.AppendLine(cmd.ToString());
                serialPort.Open();
                
                serialPort.DiscardInBuffer();

                serialPort.Write(String.Format("{0}\r", cmd.ToString()));

                //Verify response
                if (!cmd.IsQueryCommand)
                {
                    foreach (var t in cmd.ExpectedResponse)
                    {
                        char c;
                        try
                        {
                            c = (char)this.serialPort.ReadChar();
                            this.log.Append(c);
                        }
                        catch (Exception)
                        {
                            throw new Exception("ERROR!");
                        }

                        if (c != t)
                        {
                            throw new Exception("The command was not understood");
                        }
                    }
                }


                var s = await Task.Run(() =>
                {
                    var sb = new StringBuilder();
                    while (true)
                    {
                        try
                        {
                            var c = (char)serialPort.ReadChar();
                            sb.Append(c);
                            if (sb.ToString().Contains("\r\r"))
                            {
                                break;
                            }
                        }
                        catch (TimeoutException)
                        {
                            log.AppendLine(String.Format("Timed out after {0} char", sb.Length));
                            break;
                        }
                    }
                    return sb.ToString();
                });

                return s;
            }
            finally
            {
                serialPort.Close();
            }
        }

        public override async Task<Measurement> MeasureAsync(JetiCommands.Measure measureCommand)
        {
            var before = serialPort.ReadTimeout;

            serialPort.ReadTimeout = Math.Max(serialPort.ReadTimeout, (int)Math.Ceiling(measureCommand.Average * measureCommand.Tint * 2f));
            
            var str = await ExecuteAsync(measureCommand);
            var measureTime = DateTime.Now;

            serialPort.ReadTimeout = before;

            str = str.Replace(" ", "");
            var rows = str.Split('\r');
            log.AppendLine(String.Format("Found {0} row", rows.Count()));
            
            var measurements = new List<LightMeasurement>();
            var parseErrors = new List<string>();

            var nfi = new CultureInfo("en-US", false).NumberFormat;

            foreach (var m in rows)
            {
                try
                {
                    var tokens = m.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    var i = int.Parse(tokens[1]);
                    var w = double.Parse(tokens[0], NumberStyles.AllowDecimalPoint, nfi);
                    measurements.Add(new LightMeasurement { WaveLength = w, Intensity = i });
                }
                catch (Exception)
                {
                    parseErrors.Add(m);
                }
            }

            return new Measurement(measureCommand.Tint, measureCommand.Average, measurements, measureTime, measureCommand.ToString());
        }

        public override async Task SwitchLampAsync()
        {
            
            await ExecuteAsync(new Control.Lamp { Value = true });
            await ExecuteAsync(new Control.Lamp { Value = false });
            
        }

        private SerialPort SearchSerialPorts()
        {
            foreach(var pn in SerialPort.GetPortNames())
            {
                foreach (var br in this.baudRates)
                {
                    var sp = new SerialPort(pn, br) { ReadTimeout = 2000, WriteTimeout = 2000 };
                    try
                    {
                        sp.Open();
                        sp.WriteLine(String.Format("*{0}?\r", Commands.DeviceId));
                        var sb = new StringBuilder();
                        sb.Append((char)sp.ReadChar());
                        sb.Append(sp.ReadExisting());
                        if (sb.ToString().Replace("\r", "") == VERSA_PIC_DEVICE_ID)
                        {
                            return sp;
                        }
                    }
                    catch (Exception) { }
                    finally
                    {
                        sp.Close();
                    }
                }
            }
            return null;
        }
    }
}
