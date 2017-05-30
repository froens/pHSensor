namespace JetiAPI.CommandStrings
{
    internal static class Measure
    {
        /// <summary>
        /// Run dark measurement, tint ≠ 0 output output of data according to defined format
        /// </summary>
        public const string Dark = "DARK";

        /// <summary>
        /// Run light measurement and calculate the ratio to the actual reference spectrum (both dark signal subtracted) output of data according to defined format
        /// </summary>
        public const string Light = "LIGHT";

        /// <summary>
        /// Run reference measurement (Difference between light measurement and previously obtained dark measurement), same integration time as during dark scan is obligatory output of data according to defined format
        /// </summary>
        public const string Reference = "REFER";

        /// <summary>
        /// Run light measurement and calculate the ratio to the actual reference spectrum (both dark signal subtracted) output of data according to defined format
        /// </summary>
        public const string Transmission = "TRANS";
    }
}
