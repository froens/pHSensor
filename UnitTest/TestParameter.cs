using JetiAPI.JetiCommands;

namespace UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestParameter
    {
        [TestMethod]
        public void TestLampEnable()
        {
            var str0 = new Parameter.LampEnable().ToString();
            const string Str1 = "*PARA:LAMPE?";
            Assert.AreEqual(Str1, str0);

            var str2 = new Parameter.LampEnable{ Value = true }.ToString();
            const string Str3 = "*PARA:LAMPE 1";
            Assert.AreEqual(Str3, str2);
        }

        [TestMethod]
        public void TestLampPolarity()
        {
            var str0 = new Parameter.LampPolarity().ToString();
            const string Str1 = "*PARA:LAMPP?";
            Assert.AreEqual(str0, Str1);

            var str2 = new Parameter.LampPolarity { Value = true }.ToString();
            const string Str3 = "*PARA:LAMPP 1";
            Assert.AreEqual(str2, Str3);
        }


    }
}
