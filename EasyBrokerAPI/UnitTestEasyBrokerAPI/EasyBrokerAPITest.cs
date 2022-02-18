using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestEasyBrokerAPI
{
    [TestClass]
    public class UnitTestProperties
    {
        [TestMethod]
        public void TestMain()
        {
            using (var sw = new StringWriter()) {
                Console.SetOut(sw);
                EasyBrokerAPI.Program.Main();               

                var result = sw.ToString().Trim();
                Assert.IsNotNull(result);
            }
        }
    }
}
