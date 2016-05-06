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
    }
}
