using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest_Overloaded_Substring
    {
        [TestMethod]
        [DataRow("test string 123", 0, 15, "test string 123")]
        [DataRow("test string 123", 2, 6, "st str")]
        [DataRow("test string 123", 15, 0, "")]
        public void Test_Overloaded_Substring(string str, int startIndex, int length, string expected)
        {
            //act
            var actual = str.Substring(startIndex, length);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("test string 123", -1, 3)]
        [DataRow("test string 123", 10, -5)]
        [DataRow("test string 123", 16, 0)]
        [DataRow("test string 123", 11, 5)]
        public void Test_Overloaded_Substring_Null_Return_ArgumentOutOfRangeException(string str, int index, int length)
        {
            // act
            string actual = str.Substring(index, length);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        [DataRow(1, 3)]
        [DataRow(2, 7)]
        [DataRow(5, 2)]
        public void Test_Overloaded_Substring_Null_Return_NullReferenceException(int index, int length)
        {
            // arrange
            string str = null;

            // act
            string actual = str.Substring(index, length);
        }
    }
}

   