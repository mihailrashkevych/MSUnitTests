using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.Substring
{
    public class UnitTest_Substr
    {
        [TestMethod]
        [DataRow("test string 123", 1, "est string 123")]
        [DataRow("test string 123", 3, "t string 123")]
        [DataRow("test string 123", 15, "")]
        public void Test_Substring(string str, int startIndex, string expected)
        {
            //act
            var actual = str.Substring(startIndex);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(5)]
        public void Test_Substring_Null_Return_NullReferenceException(int index)
        {
            // arrange
            string str = null;

            // act
            str.Substring(index);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("test string 123", -1)]
        [DataRow("test string 123", -21)]
        [DataRow("test string 123", -8)]
        public void Test_Substring_Null_Return_ArgumentOutOfRangeException(string str, int index)
        {
            // act
            str.Substring(index);
        }
    }
}

