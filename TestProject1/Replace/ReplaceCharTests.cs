using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.Replace
{
    [TestClass]
    public class ReplaceCharTests
    {
        [TestMethod]
        [DataRow("test !@#$%^&* string 123", 's', 'c', "tect !@#$%^&* ctring 123")]
        [DataRow("test !@#$%^&* string 123", ' ', '_', "test_!@#$%^&*_string_123")]

        [DataRow("test !@#$%^&* string 123", '#', '▓', "test !@▓$%^&* string 123")]
        [DataRow("test !@#$%^&* string 123", null, 'c', "test !@#$%^&* string 123")]
        [DataRow("test !@#$%^&* string 123", ' ', null, "test\0!@#$%^&*\0string\0123")]
        public void Test_Replace(string str, char oldChar, char newChar, string expected)
        {
            //act
            var actual = str.Replace(oldChar, newChar);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        [DataRow(null, ' ', 'c')]
        public void Test_Replace_Return_NullReferenceException(string str, char oldChar, char newChar)
        {
            //act
            var actual = str.Replace(oldChar, newChar);
        }
    }
}

