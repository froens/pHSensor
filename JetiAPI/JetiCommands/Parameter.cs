using System;
using JetiAPI.CommandStrings;

namespace JetiAPI.JetiCommands
{
    public class Parameter : JetiCommand
    {
        protected override string CmdStr
        {
            get { return CommandStrings.Commands.Parameter; }
        }

        protected override string SubCmdStr { get { return null; } }

        public override string ExpectedResponse
        {
            get { return Responses.ACK.ToString(); }
        }

        /***************************
         *    GENERAL SETTINGS     *
         ***************************/

        /// <summary>
        /// Get/Set ADC resolution
        /// </summary>
        [QueryableCommand]
        public class ADCResolution : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.ADCResolution; } }
        }

        /// <summary>
        /// Get/Set input voltage range of ADC
        /// (1 = 2V, 0 = 4V)
        /// </summary>
        [QueryableCommand]
        public class ADCVoltage : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.ADCVoltage; } }
        }

        /// <summary>
        /// Get/ Set baudrate
        /// 38 400 Bd: 384
        /// 115 200 Bd: 115
        /// 921 000 Bd: 921 (default value)
        /// </summary>
        [QueryableCommand]
        public class Baudrate : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.Baudrate; } }
        }

        /// <summary>
        /// Get power down active (on = 1, off = 0will be deactivated automatically with the next command
        /// </summary>
        [QueryableCommand]
        public class ActivePowerDown : Parameter
        {
            protected override string SubCmdStr { get { return CommandStrings.Parameter.ActivePowerDown; } }
        }

        /// <summary>
        /// Get pixel quantity
        /// </summary>
        [QueryableCommand]
        public class Pixels : Parameter
        {
            protected override string SubCmdStr { get { return CommandStrings.Parameter.Pixels; } }
        }

        /// <summary>
        /// Get sensor type
        /// </summary>
        [QueryableCommand]
        public class SensorType : Parameter
        {
            protected override string SubCmdStr { get { return CommandStrings.Parameter.SensorType; } }
        }

        /// <summary>
        /// Get serial number (internal number)
        /// </summary>
        [QueryableCommand]
        public class SerialNumber : Parameter
        {
            protected override string SubCmdStr { get { return CommandStrings.Parameter.SerialNumber; } }
        }

        /// <summary>
        /// Get spectrometer number
        /// </summary>
        [QueryableCommand]
        public class SpectrometerNumber : Parameter
        {
            protected override string SubCmdStr { get { return CommandStrings.Parameter.SpectrometerNumber; } }
        }


        
        /************************
         *    TIME SETTINGS     *
         ************************/


        /// <summary>
        ///  Get/ Set default integration time
        /// </summary>
        [QueryableCommand]
        public class IntegrationTime : Parameter
        {
            [JetiArgument(0, "tint")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.IntegrationTime; } }
        }

        /// <summary>
        /// Get/ Set scan delay (time difference between initiating a measurement and its real start, in ms)
        /// </summary>
        [QueryableCommand]
        public class ScanDelay : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.ScanDelay; } }
        }

        /// <summary>
        /// Get/ Set low and high border for the adaption of integration time (percent of fullscale)
        /// </summary>
        [QueryableCommand]
        public class Border : Parameter
        {
            [JetiArgument(0, "low")]
            public int? Low { get; set; }

            [JetiArgument(1, "high")]
            public int? High { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.Border; } }
        }

        /// <summary>
        /// Get/ Set time to next fast cycle (in ms)
        /// </summary>
        [QueryableCommand]
        public class FastScan : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.FastScan; } }
        }

        /// <summary>
        /// Get/ Set parameters (flash interval in ms and length in μs) for control of an external flash lamp (pinout of connector see next chapter) number of flashes = tint/ flash interval
        /// </summary>
        [QueryableCommand]
        public class Flashlight : Parameter
        {
            [JetiArgument(0, "interval")]
            public int? Interval { get; set; }

            [JetiArgument(1, "length")]
            public int? Leghth { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.Flashlight; } }
        }

        /******************************************
         *    Settings for Peripherical Units     *
         ******************************************/

        /// <summary>
        /// Get/ Set external lamp or shutter active 
        /// (enable = 1, disable = 0), 
        /// only if lamp or shutter are enabled, they can be used
        /// </summary>
        [QueryableCommand]
        public class LampEnable : Parameter
        {
            [JetiArgument(0, "arg")]
            public bool? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.LampEnable; } }
        }

        /// <summary>
        /// Get/ set external lamp or shutter polarity
        /// (low = 0, high = 1)
        /// </summary>
        [QueryableCommand]
        public class LampPolarity : Parameter
        {
            [JetiArgument(0, "arg")]
            public bool? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.LampPolarity; } }
        }

        /// <summary>
        /// Get/ Set trigger mode (enable = 1, disable = 0), start of a configured measurement with hardware trigger (shortcut with switch or TTL signal), similar to the command *INITiate, last output: 07 (measurement finished, data are ready)
        /// </summary>
        [QueryableCommand]
        public class TriggerMode : Parameter
        {
            [JetiArgument(0, "arg")]
            public bool? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.TriggerMode; } }
        }

        /// <summary>
        /// Get/ Set trigger slope (triggering with switch closing/ falling TTL signal = 1, with switch opening/ rising TTL signal = 0)
        /// </summary>
        [QueryableCommand]
        public class TriggerSlope : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.TriggerSlope; } }
        }

        /// <summary>
        /// Get/Set shutter availability (available = 1 (dark measurement with shutter possible), not available = 0 (only dark compensation possible))
        /// </summary>
        [QueryableCommand]
        public class Shutter : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.Shutter; } }
        }



        /***********************************
         *    Settings for measurement     *
         ***********************************/
        
        
        /// <summary>
        /// Get/ Set offset value (-250 … 250 mV)
        /// </summary>
        [QueryableCommand]
        public class Offset : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.Offset; } }
        }


        /// <summary>
        /// Get/ Set gain value (1.0 … 5.0)
        /// </summary>
        [QueryableCommand]
        public class Gain : Parameter
        {
            [JetiArgument(0, "arg")]
            public double? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.Gain; } }
        }

        /// <summary>
        /// Get/ Set wavelength fit parameters
        /// </summary>
        [QueryableCommand]
        public class Fit : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.Fit; } }
        }

        /// <summary>
        /// Get configured basic parameters
        /// </summary>
        [QueryableCommand]
        public class BasicParameters : Parameter
        {
            protected override string SubCmdStr { get { return CommandStrings.Parameter.BasicParameters; } }
        }

        /// <summary>
        /// Get configured extended parameters
        /// </summary>
        [QueryableCommand]
        public class ExtendedParameters : Parameter
        {
            protected override string SubCmdStr { get { return CommandStrings.Parameter.ExtendedParameters; } }
        }

        /// <summary>
        /// Get a list of all parameters
        /// </summary>
        [QueryableCommand]
        public class AllParameters : Parameter
        {
            protected override string SubCmdStr { get { return CommandStrings.Parameter.AllParameters; } }
        }

        /// <summary>
        /// Get/ Set boxcar mode (running average of pixels, odd number (1 … 25), 1 – no boxcar integration)
        /// </summary>
        [QueryableCommand]
        public class BoxCarIntegration : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.BoxCarIntegration; } }
        }

        /// <summary>
        /// Get/set predefined exposure mode (handling of integration time tint)
        /// 0 – uses previous tint (default value)
        /// 1 – always adaption of tint
        /// 2 – uses configured tint (see *CONF:TINT)
        /// </summary>
        [QueryableCommand]
        public class Exposure : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.Exposure; } }
        }

        /// <summary>
        /// Get/ set predefined adaption mode (adaption of tint in case of over/ under exposure or no adaption)
        /// 0 – no adaption if under or overexposure
        /// 1 – new adaption only if overexposure
        /// 2 – new adaption if under or overexposure
        /// </summary>
        [QueryableCommand]
        public class AdaptionMode : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.AdaptionMode; } }
        }

        /// <summary>
        /// Get/ set predefined output format
        /// </summary>
        [QueryableCommand]
        public class Format : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.Format; } }
        }

        /// <summary>
        /// Get/ set predefined measurement function
        /// </summary>
        [QueryableCommand]
        public class MeasurementFunction : Parameter
        {
            [JetiArgument(0, "arg")]
            public int? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.MeasurementFunction; } }
        }


        /**********************************
         *    Settings for Faultpixel     *
         **********************************/

        /// <summary>
        /// Get/ set predefined measurement function
        /// </summary>
        [QueryableCommand]
        public class FaultPixel : Parameter
        {
            [JetiArgument(1, "arg1")]
            public int? Value1 { get; set; }

            [JetiArgument(2, "arg2")]
            public int? Value2 { get; set; }

            [JetiArgument(3, "arg3")]
            public int? Value3 { get; set; }

            [JetiArgument(4, "arg4")]
            public int? Value4 { get; set; }

            [JetiArgument(5, "arg5")]
            public int? Value5 { get; set; }

            [JetiArgument(6, "arg6")]
            public int? Value6 { get; set; }

            [JetiArgument(7, "arg7")]
            public int? Value7 { get; set; }

            [JetiArgument(8, "arg8")]
            public int? Value8 { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Parameter.FaultPixel; } }
        }



        /***********************************
         * Permanent Storage of Parameters *
         ***********************************/

        /// <summary>
        /// Get/ set predefined measurement function
        /// </summary>
        public class Save : Parameter
        {
            protected override string SubCmdStr { get { return CommandStrings.Parameter.Save; } }
        }
    }
}
