using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VCommerceAdmin.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrage
            var a = 1;
            var b = 2;

            //Act
            var c = a + b;

            //Assert
            Assert.AreEqual(3, c);
        }
    }
}
