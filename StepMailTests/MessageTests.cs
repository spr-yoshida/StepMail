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
    public class MessageTests
    {
        [TestMethod()]
        public void ReadTest()
        {
            var currentDir = Directory.GetCurrentDirectory();
            var fileDir = "subDir";
            var filePath = Path.Combine(currentDir, fileDir);

            var target = new Message();
            target.Read(filePath);

            var actual = 3;
            var expected = target.Messages.Count();
            Assert.AreEqual(expected, actual);
        }
    }
}