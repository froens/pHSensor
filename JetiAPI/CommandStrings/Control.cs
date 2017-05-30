using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetiAPI.CommandStrings
{
    internal static class Control
    {
        /// <summary>
        /// Get/ Set auxiliary output 1
        /// </summary>
        public const string Aux1 = "AUX1";

        /// <summary>
        /// Get/ Set auxiliary output 2
        /// </summary>
        public const string Aux2 = "AUX2";

        /// <summary>
        /// Get/ Set lamp/ shutter status (1 – lamp on, shutter opened, 0 – lamp off, shutter closed)
        /// </summary>
        public const string Lamp = "LAMP";
    }
}
