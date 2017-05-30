namespace JetiAPI.CommandStrings
{
    internal static class Commands
    {
        /// <summary>
        /// Get firmware version
        /// </summary>
        public const string Version = "VERS";

        /// <summary>
        /// Software reset
        /// </summary>
        public const string Reset = "RST";

        /// <summary>
        /// Get device ID
        /// </summary>
        public const string DeviceId = "IDN";

        /// <summary>
        /// Get and set general parameters
        /// </summary>
        public const string Parameter = "PARA";

        /// <summary>
        /// Get and set configuration data
        /// </summary>
        public const string Configure = "CON";

        /// <summary>
        /// Start a configured measurement
        /// </summary>
        public const string Initiate = "INIT";

        /// <summary>
        /// Get data from previous measurement
        /// </summary>
        public const string Fetch = "FETCH";

        /// <summary>
        /// Start a configured measurement and get the data (combination of *INIT and *FETCH)
        /// </summary>
        public const string Read = "READ";

        /// <summary>
        /// Configure, start the measurement and get the data (combination of *CONF, *INIT and *FETCH)
        /// </summary>
        public const string Measure = "MEAS";

        /// <summary>
        /// Control peripherical components
        /// </summary>
        public const string Control = "CONTR";

        /// <summary>
        /// Calculate data from the previous measurement
        /// </summary>
        public const string Calculate = "CALC";

        /// <summary>
        /// Information about error and configuration status
        /// </summary>
        public const string Status = "STAT";

        /// <summary>
        /// Output of help information
        /// </summary>
        public const string Help = "HELP";

        /// <summary>
        /// Write parameter field (1024 Byte)
        /// </summary>
        public const string WriteParameter = "WRPARA";

        /// <summary>
        /// Read parameter field (1024 Byte)
        /// </summary>
        public const string ReadParameter = "RDPARA";

        /// <summary>
        /// Read 1k of 16k user data
        /// </summary>
        public const string ReadUserData = "RDUSR2";

        /// <summary>
        /// Write 1k of 16k user data
        /// </summary>
        public const string WriteUserData = "WRUSR2";
    }
}
