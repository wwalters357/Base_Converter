using Microsoft.VisualStudio.TestTools.UnitTesting;
using App_Test;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace App_Test.Tests
{
    [TestClass()]
    public class MainPageTests
    {
        [TestMethod()]
        public void Convert_To_DecimalTest()
        {
            Number number = new Number(12345, 8, 10);
            int expected = 5349;
            int result = number.Convert_To_Decimal();
            Assert.AreEqual(expected, result);
        }
    }
}