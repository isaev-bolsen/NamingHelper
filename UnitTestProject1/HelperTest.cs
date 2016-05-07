using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassGenerator.Host
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
        public void ConvertToValidNameTest()
        {
            Assert.AreEqual("Zloy123Admin_456", Helper.ConvertToValidCSName("456Zloy123Admin"));
        }

        [TestMethod]
        public void ConvertToValidNameTest2()
        {
            Assert.AreEqual("Zloy123Admin456", Helper.ConvertToValidCSName("Zloy123Admin 456"));
        }
    }
}
