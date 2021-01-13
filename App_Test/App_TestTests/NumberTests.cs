using Microsoft.VisualStudio.TestTools.UnitTesting;
using App_Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Test.Tests
{
    [TestClass()]
    public class NumberTests
    {
        [TestMethod()]
        public void Convert_To_DecimalTest()
        {
            Number number = new Number(12345, 8, 10);
            int expected = 5349;
            int result = number.Convert_To_Decimal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Convert_From_DecimalTest()
        {
            Number number = new Number(5349, 10, 8);
            char[] expected = { '5', '4', '3', '2', '1' };
            char[] result = number.Convert_From_Decimal((int)number.Value);
            CollectionAssert.AreEqual(expected, result);

            number = new Number(5349, 10, 2);
            char[] expected2 = { '1', '0', '1', '0', '0', '1', '1', '1', '0', '0', '1', '0', '1' };
            result = number.Convert_From_Decimal((int)number.Value);
            CollectionAssert.AreEqual(expected2, result);
        }

        [TestMethod()]
        public void Convert_From_DecimalTest2()
        {
            Number number = new Number(5349, 10, 2);
            char[] expected = { '1', '0', '1', '0', '0', '1', '1', '1', '0', '0', '1', '0', '1' };
            char[] result = number.Convert_From_Decimal((int)number.Value);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Reverse_ArrayTest()
        {
            Number number = new Number(0, 0, 0);
            char[] arr = { '1', '2', '3', '4', '5' };
            char[] expected = { '5', '4', '3', '2', '1' };
            char[] result = number.Reverse_Array(arr);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Convert_NumberTest()
        {
            Number number = new Number(12345, 8, 2);
            string expected = "1010011100101";
            string result = number.Convert_Number();
            Assert.AreEqual(expected, result);
        }
    }
}