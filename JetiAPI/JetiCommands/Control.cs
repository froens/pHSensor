using System;
using JetiAPI.CommandStrings;

namespace JetiAPI.JetiCommands
{
    [QueryableCommand]
    public class Control : JetiCommand
    {
        protected override string CmdStr
        {
            get { return CommandStrings.Commands.Control; }
        }

        protected override string SubCmdStr { get { return null; } }

        public override string ExpectedResponse
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Get/ Set auxiliary output 1
        /// </summary>
        public class Aux1 : Control
        {
            [JetiArgument(0, "arg")]
            public bool? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Control.Aux1; } }
        }

        /// <summary>
        /// Get/ Set auxiliary output 2
        /// </summary>
        public class Aux2 : Control
        {
            [JetiArgument(0, "arg")]
            public bool? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Control.Aux2; } }
        }

        /// <summary>
        /// Get/ Set lamp/ shutter status (1 – lamp on, shutter opened, 0 – lamp off, shutter closed)
        /// </summary>
        public class Lamp : Control
        {
            [JetiArgument(0, "arg")]
            public bool? Value { get; set; }

            protected override string SubCmdStr { get { return CommandStrings.Control.Lamp; } }
        }
    }
}
