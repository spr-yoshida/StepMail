using Microsoft.VisualStudio.TestTools.UnitTesting;
using StepMail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepMail.Tests
{
    [TestClass()]
    public class MembersTests
    {
        [TestMethod()]
        public void ReadTest()
        {
            var target = new Members();
            var currentDir = Directory.GetCurrentDirectory();
            var fileName = "members.json";
            var filePath = Path.Combine(currentDir, fileName);
            target.Read(filePath);

            var expected = 3;
            var actual = target.Profiles.Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetActiveUsersTest()
        {
            var currentDir = Directory.GetCurrentDirectory();
            var fileName = "members.json";
            var filePath = Path.Combine(currentDir, fileName);
            Members.Initailze(filePath);

            var target = new Members();
            target.Read(filePath);
            var result = target.GetActiveUsers(2);

            var expected = 2;
            var actual = result.Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CountUpTest()
        {
            var currentDir = Directory.GetCurrentDirectory();
            var fileName = "members.json";
            var filePath = Path.Combine(currentDir, fileName);
            Members.Initailze(filePath);

            var target = new Members();
            target.Read(filePath);
            target.CountUp();

            var expected01 = 2;
            var actual01 = target.Profiles[0].Count;
            Assert.AreEqual(expected01, actual01);

            var expected02 = 3;
            var actual02 = target.Profiles[1].Count;
            Assert.AreEqual(expected02, actual02);

            var expected03 = 3;
            var actual03 = target.Profiles[1].Count;
            Assert.AreEqual(expected03, actual03);

        }

        [TestMethod()]
        public void InitailzeTest()
        {
            var currentDir = Directory.GetCurrentDirectory();
            var fileName = "members.json";
            var filePath = Path.Combine(currentDir, fileName);
            Members.Initailze(filePath);

            var target = new Members();
            target.Read(filePath);

            var expected = 3;
            var actual = target.Profiles.Count();
            Assert.AreEqual(expected, actual);
        }
    }
}