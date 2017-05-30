using System.Threading;

namespace UnitTest
{
    using JetiAPI;
    using JetiAPI.JetiCommands;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestControl
    {
        
        [TestMethod]
        public void TestControlLamp()
        {
            var cmd = new Control.Lamp {Value = true};
            const string CmdExpected = "*CONTR:LAMP 1";
            Assert.AreEqual(CmdExpected, cmd.ToString());
        }

        [TestMethod]
        public void TestControlLampQuery()
        {
            var cmd = new Control.Lamp().ToString();
            const string CmdExpected = "*CONTR:LAMP?";
            Assert.AreEqual(CmdExpected, cmd);
        }


        [TestMethod]
        public void TestExecuteLamp()
        {
#if DEBUG
            var spektro = new FakeSpectrometer();
#else
            var spektro = new JetiSpectrometer();
#endif

            spektro.Execute(new Control.Lamp { Value = true });
            Thread.Sleep(2000);
            spektro.Execute(new Control.Lamp { Value = false });
        }
    }
}
