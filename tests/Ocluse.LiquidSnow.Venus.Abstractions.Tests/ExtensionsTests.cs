using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ocluse.LiquidSnow.Venus.Tests
{
    [TestClass()]
    public class ExtensionsTests
    {
        [TestMethod()]
        public void ToKMBTest()
        {
            decimal num = 7890;

            var result = num.ToKMB();

            Assert.AreEqual("7.9K", result);
        }
    }
}