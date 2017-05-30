using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetiAPI
{
    public class Lamp
    {
        public bool IsOn { get; set; }
        private SerialPort _serialport;


        public Lamp(SerialPort serialport)
        {
            _serialport = serialport;

        }
    }
}
