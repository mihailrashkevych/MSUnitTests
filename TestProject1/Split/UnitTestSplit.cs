using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.Split
{
    public class UnitTestSplit
    {
        [TestMethod]
        [DataRow("test string, 123", new[] { ' ', ',' }, Int32.MaxValue, new[]{"test", "string", "", "123"}, StringSplitOptions.None)]
        [DataRow("test string, 123", new[] { ' ', ',' }, 2, new[] { "test string", "123" }, 0)]
        [DataRow("test string, 123", new[] { ' ', ',' }, 0, new[] { "test string, 123" }, 0)]
        [DataRow("test string, 123", new[] { ' ', ',' }, Int32.MaxValue, new[] { "test", "string", "123" }, StringSplitOptions.RemoveEmptyEntries)]
        [DataRow(" test , string , 123 ", new[] { ',' }, Int32.MaxValue, new[] { "test", "string", "123" }, StringSplitOptions.TrimEntries)]

        public void Test_Split_Char(string str, char[] separator, int count,  string[] expected, StringSplitOptions options)
        {
            //act
            var actual = str.Split(separator, count, options);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("test string, 123", new[] { ' ', ',' }, Int32.MinValue, StringSplitOptions.None)]
        [DataRow("test string, 123", new[] { ' ', ',' }, -1, StringSplitOptions.RemoveEmptyEntries)]
        [DataRow("test string, 123", new[] { ' ', ',' }, 1, -1)]
        [DataRow("test string, 123", new[] { ' ', ',' }, Int32.MinValue, 3)]
        public void Test_Split_Char_Return_ArgumentException(string str, char[] separator, int count, StringSplitOptions options)
        {
            // act
            str.Split(separator, count, options);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        [DataRow(null, new[] { ' ', ',' }, Int32.MaxValue)]
        [DataRow("test string, 123", null, 2)]
        [DataRow("test string, 123", new[] { ' ', ',' }, null)]
        public void Test_Split_Char_Null_Return_NullReferenceException(string str, char[] separator, int count)
        {
            // act
            var actual = str.Split(separator, count);
        }
    }
}
