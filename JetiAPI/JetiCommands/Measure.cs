using System;
using JetiAPI.CommandStrings;

namespace JetiAPI.JetiCommands
{
    public class Measure : JetiCommand
    {
        public Measure()
        {
            Format = 7;
        }

        protected override string CmdStr
        {
            get { return Commands.Measure; }
        }

        protected override string SubCmdStr { get { return null; } }

        public override string ExpectedResponse
        {
            get { return String.Format("{0}{1}", Responses.ACK, Responses.BELL); }
        }

        [JetiArgument(0, ArgumentStrings.Tint)]
        public int Tint { get; set; }

        [JetiArgument(2, ArgumentStrings.Format)]
        public int Format { get; set; }

        [JetiArgument(1, ArgumentStrings.Average)]
        public int Average { get; set; }

        public class Dark : Measure
        {
            protected override string SubCmdStr { get { return CommandStrings.Measure.Dark; } }
        }

        public class Light : Measure
        {
            protected override string SubCmdStr { get { return CommandStrings.Measure.Light; } }
        }

        public class Referenece : Measure
        {
            protected override string SubCmdStr { get { return CommandStrings.Measure.Reference; } }
        }

        public class Transmission : Measure
        {
            protected override string SubCmdStr { get { return CommandStrings.Measure.Transmission; } }
        }
    }
}
