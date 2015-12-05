using Microsoft.VisualStudio.TestTools.UnitTesting;
using StepMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepMail.Tests
{
    [TestClass()]
    public class MailTests
    {
        [TestMethod()]
        public void CreateMail_To_Test()
        {
            var target = Mail.CreateMail("ToUser1", "CCUser1", 1, "");
            var expected_To = "ToUser1";
            var actual_To = target.To;
            Assert.AreEqual(expected_To, actual_To);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var target = Mail.CreateMail("u1@example.com", "c1@example.com", 1, @"a001
fdsakj;lj
dijfoe
daf
dfa");
            var expected = @"To:u1@example.com CC:c1@example.com Title:配信　第001号 Body:Sub Title
a001
fdsakj;lj
dijfoe
daf
dfa
(c) 2015
";
            var actual = target.ToString();

            Assert.AreEqual(expected, actual);
        }
        

        
    }
}