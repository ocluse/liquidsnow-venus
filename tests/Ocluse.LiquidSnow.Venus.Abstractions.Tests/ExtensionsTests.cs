using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ocluse.LiquidSnow.Venus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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