using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.Split
{
    [TestClass]
    public class SplitStringTests
    {
        [TestMethod]
        [DataRow("test string, 123. test string, 123", new[] { "string", "123" }, Int32.MaxValue, new[] { "test ", ", ", ". test ", ", ", "" }, StringSplitOptions.None)]
        [DataRow("test string, 123. test string, 123", new[] { "str", "23" }, 2, new[] { "test ", "ing, 123. test string, 123" }, 0)]
        [DataRow("test string, 123. test string, 123", new[] { "str", "23" }, 0, new string[] { }, 0)]
        [DataRow("test string, 123. test string, 123", new[] { "str", "23" }, Int32.MaxValue, new[] { "test ", "ing, 1", ". test ", "ing, 1" }, StringSplitOptions.RemoveEmptyEntries)]
        [DataRow(" test string, 123. test string, 123 ", new[] { "str", "23" }, Int32.MaxValue, new[] { "test", "ing, 1", ". test", "ing, 1", "" }, StringSplitOptions.TrimEntries)]
        public void Test_Split_String(string str, string[] separator, int count, string[] expected, StringSplitOptions options)
        {
            //act
            var actual = str.Split(separator, count, options);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("test string, 123", new[] { "str", "23" }, Int32.MaxValue, -1)]
        [DataRow("test string, 123. test string, 123", "", 2, StringSplitOptions.RemoveEmptyEntries)]
        public void Test_Split_String_Return_ArgumentException(string str, string[] separator, int count, StringSplitOptions options)
        {
            // act
            str.Split(separator, count, options);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("test string, 123", new[] { "str", "23" }, Int32.MinValue, StringSplitOptions.None)]
        [DataRow("test string, 123", new[] { "str", "23" }, -1, StringSplitOptions.RemoveEmptyEntries)]
        [DataRow("test string, 123", new[] { "str", "23" }, Int32.MinValue, 3)]
        public void Test_Split_Char_Return_ArgumentOutOfRangeException(string str, string[] separator, int count, StringSplitOptions options)
        {
            // act
            str.Split(separator, count, options);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        [DataRow(null, new[] { "str", "23" }, Int32.MaxValue, StringSplitOptions.None)]
        public void Test_Split_String_Return_NullReferenceException(string str, string[] separator, int count, StringSplitOptions options)
        {
            // act
            str.Split(separator, count, options);
        }
    }
}
