using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.Replace
{
    [TestClass]
    public class ReplaceStringTests
    {
        [TestMethod]
        [DataRow("test !@#$%^&* string 123", "test !@#", "unit test ", "unit test $%^&* string 123")]
        [DataRow("test !@#$%^&* string 123", "test !@#$%^&* string 123", "unit test for replace method", "unit test for replace method")]
        [DataRow("test !@#$%^&* string 123", "!@#$%^&*", null, "test  string 123")]
        public void Test_Replace(string str, string oldChar, string newChar, string expected)
        {
            //act
            var actual = str.Replace(oldChar, newChar);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        [DataRow(null, "test !@#", "!@#$%^&*")]
        [DataRow(null, "!@#$%^&*", "test !@#")]
        public void Test_Replace_Return_NullReferenceException(string str, string oldChar, string newChar)
        {
            //act
            str.Replace(oldChar, newChar);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow("test !@#$%^&* string 123", null, "!@#$%^&*")]
        public void Test_Replace_Return_ArgumentNullException(string str, string oldChar, string newChar)
        {
            //act
            str.Replace(oldChar, newChar);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("", "", "")]
        [DataRow("test !@#$%^&* string 123", "", "")]
        public void Test_Replace_Return_ArgumentException(string str, string oldChar, string newChar)
        {
            //act
            str.Replace(oldChar, newChar);
        }
    }
}
