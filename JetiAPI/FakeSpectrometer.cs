namespace JetiAPI
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using JetiAPI.JetiCommands;

    public class FakeSpectrometer : BaseSpectrometer
    {
        private readonly Random random = new Random();

        public async override Task<string> ExecuteAsync(JetiCommand cmd)
        {
            log.AppendLine(cmd.ToString());
            await Task.Delay(random.Next(1000, 4000));
            return "HUdasdsadsadsadsadsadsadsadsadsa!";
        }

        public async override Task<Measurement> MeasureAsync(JetiCommands.Measure measureCommand)
        {
            log.AppendLine(measureCommand.ToString());
            await Task.Delay(random.Next(1000, 4000));

            var measurements = new List<LightMeasurement>();

            var rnd = new Random();
            var last = 0;
            for (var i = 0; i < 3000; i++)
            {
                var next = Math.Max(0, last + rnd.Next(-100, 100));
                measurements.Add(new LightMeasurement { WaveLength = i, Intensity = next });
                last = next;
            }
            return new Measurement(measureCommand.Tint, measureCommand.Average, measurements, DateTime.Now, measureCommand.ToString());
        }

        public override Task SwitchLampAsync()
        {
            return ExecuteAsync(new Control.Lamp { Value = true });
        }
    }
}
