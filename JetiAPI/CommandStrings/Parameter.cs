using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetiAPI.CommandStrings
{
    internal static class Parameter
    {
        /*********************************
         * GENERAL SETTINGS (Parameters) *
         *********************************/
        
        /// <summary>
        /// Get spectrometer number
        /// </summary>
        public const string SpectrometerNumber = "SPNUM";

        /// <summary>
        /// Get serial number (internal number)
        /// </summary>
        public const string SerialNumber = "SERN";

        /// <summary>
        /// Get pixel quantity
        /// </summary>
        public const string Pixels = "PIX";

        /// <summary>
        /// Get sensor type
        /// </summary>
        public const string SensorType = "SENS";

        /// <summary>
        /// Get/Set ADC resolution
        /// </summary>
        public const string ADCResolution = "ADCR";

        /// <summary>
        /// Get/Set input voltage range of ADC
        /// (1 = 2V, 0 = 4V)
        /// </summary>
        public const string ADCVoltage = "ADCV";

        /// <summary>
        /// Get power down active (on = 1, off = 0will be deactivated automatically with the next command
        /// </summary>
        public const string ActivePowerDown = "ADPW";

        /// <summary>
        /// Get/ Set baudrate
        /// 38 400 Bd: 384
        /// 115 200 Bd: 115
        /// 921 000 Bd: 921 (default value)
        /// </summary>
        public const string Baudrate = "BAUD";


        /***********************************
         * Time Settings *
         ***********************************/

        /// <summary>
        /// Get/ Set default integration time
        /// </summary>
        public const string IntegrationTime = "TINT";

        /// <summary>
        /// Get/ Set scan delay (time difference between initiating a measurement and its real start, in ms)
        /// </summary>
        public const string ScanDelay = "SDEL";

        /// <summary>
        /// Get/ Set low and high border for the adaption of integration time (percent of fullscale)
        /// </summary>
        public const string Border = "BORD";

        /// <summary>
        /// Get/ Set time to next fast cycle (in ms)
        /// </summary>
        public const string FastScan = "FAST";

        /// <summary>
        /// Get/ Set parameters (flash interval in ms and length in μs) for control of an external flash lamp (pinout of connector see next chapter) number of flashes = tint/ flash interval
        /// </summary>
        public const string Flashlight = "FLASH";


        /***********************************
         * SETTINGS FOR PERIPHERICAL UNITS *
         ***********************************/

        /// <summary>
        /// Get/ Set external lamp or shutter active 
        /// (enable = 1, disable = 0), 
        /// only if lamp or shutter are enabled, they can be used
        /// </summary>
        public const string LampEnable = "LAMPE";

        /// <summary>
        /// Get/ set external lamp or shutter polarity
        /// (low = 0, high = 1)
        /// </summary>
        public const string LampPolarity = "LAMPP";
        
        /// <summary>
        /// Get/ Set trigger mode (enable = 1, disable = 0), start of a configured measurement with hardware trigger (shortcut with switch or TTL signal), similar to the command *INITiate, last output: 07 (measurement finished, data are ready)
        /// </summary>
        public const string TriggerMode = "TRIG";

        /// <summary>
        /// Get/ Set trigger slope (triggering with switch closing/ falling TTL signal = 1, with switch opening/ rising TTL signal = 0)
        /// </summary>
        public const string TriggerSlope = "TRSL";

        /// <summary>
        /// Get shutter availability (available = 1 (dark measurement with shutter possible), not available = 0 (only dark compensation possible))
        /// </summary>
        public const string Shutter = "SHUT";


        /****************************
         * Settings for LightMeasurement *
         ****************************/
        
        /// <summary>
        /// Get/ Set offset value (-250 … 250 mV)
        /// </summary>
        public const string Offset = "OFFS";

        /// <summary>
        /// Get/ Set gain value (1.0 … 5.0)
        /// </summary>
        public const string Gain = "GAIN";

        /// <summary>
        /// Get/ Set wavelength fit parameters
        /// </summary>
        public const string Fit = "FIT";

        /// <summary>
        /// Get configured basic parameters
        /// </summary>
        public const string BasicParameters = "BASIC";

        /// <summary>
        /// Get configured extended parameters
        /// </summary>
        public const string ExtendedParameters = "EXTEND";

        /// <summary>
        /// Get a list of all parameters
        /// </summary>
        public const string AllParameters = "ALLPARA";

        /// <summary>
        /// Get/ Set boxcar mode (running average of pixels, odd number (1 … 25), 1 – no boxcar integration)
        /// </summary>
        public const string BoxCarIntegration = "BOXCA";

        /// <summary>
        /// Get/set predefined exposure mode (handling of integration time tint)
        /// </summary>
        public const string Exposure = "EXPO";

        /// <summary>
        /// Get/ set predefined adaption mode (adaption of tint in case of over/ under exposure or no adaption)
        /// </summary>
        public const string AdaptionMode = "ADAP";

        /// <summary>
        /// Get/ set predefined output format
        /// </summary>
        public const string Format = "FORM";

        /// <summary>
        /// Get/ set predefined measurement function
        /// </summary>
        public const string MeasurementFunction = "FUNC";

        
        
        /****************************
         * Settings for Faultpixel  *
         ****************************/

        /// <summary>
        /// Get/ set Set faulty pixel
        /// </summary>
        public const string FaultPixel = "FAULTPI";


        
        /***********************************
         * Permanent Storage of Parameters *
         ***********************************/

        /// <summary>
        /// Get/ set Set faulty pixel
        /// </summary>
        public const string Save = "SAVE";
    }
}
