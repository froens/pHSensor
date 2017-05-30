namespace JetiAPI
{
    using System.Text;
    using System.Threading.Tasks;

    public abstract class BaseSpectrometer
    {
        public abstract Task<string> ExecuteAsync(JetiCommand cmd);
        protected readonly StringBuilder log = new StringBuilder();
        public string Execute(JetiCommand cmd)
        {
            var t = this.ExecuteAsync(cmd);
            t.Wait();
            return t.Result;
        }

        public string ReadLog()
        {
            return this.log.ToString();
        }

        public abstract Task<Measurement> MeasureAsync(JetiCommands.Measure measureCommand);
        public Measurement Measure(JetiCommands.Measure measureCommand)
        {
            var t = this.MeasureAsync(measureCommand);
            t.Wait();
            return t.Result;
        }

        public abstract Task SwitchLampAsync();
        public void SwitchLamp()
        {
            SwitchLampAsync().Wait();
        }
    }
}
