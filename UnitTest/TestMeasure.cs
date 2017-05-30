namespace UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Measure = JetiAPI.JetiCommands.Measure;

    [TestClass]
    public class TestMeasure
    {
        [TestMethod]
        public void TestMeasurement()
        {
            var cmd = new Measure {Average = 7, Format = 4, Tint = 100}.ToString();
            const string CmdExpected = "*MEAS 100 7 4";
            Assert.AreEqual(CmdExpected, cmd);
        }

        [TestMethod]
        public void TestMeasurementDark()
        {
            var cmd = new Measure.Dark { Average = 7, Format = 4, Tint = 100 }.ToString();
            const string CmdExpected = "*MEAS:DARK 100 7 4";
            Assert.AreEqual(CmdExpected, cmd);
        }

        [TestMethod]
        public void TestMeasurementReference()
        {
            var cmd = new Measure.Referenece { Average = 7, Format = 4, Tint = 100 }.ToString();
            const string CmdExpected = "*MEAS:REFER 100 7 4";
            Assert.AreEqual(CmdExpected, cmd);
        }
    }
}
