using EmailSystem.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSystem.BL.Tests
{
    [TestClass]
    public class EmailModelTests
    {
        [DataTestMethod]
        [DataRow("This is a string above 20 characters")]
        [DataRow("This is a string aboveÆ")]
        [DataRow("This is aø")]
        public void GetMessageTeaser_StringAbove10_ShouldReturn10LengthString(string message)
        {
            EmailModel emailModel = new EmailModel()
            {
                Message = message
            };

            int expected = 10;

            string emailMessage = emailModel.GetMessageTeaser();

            int actual = emailMessage.Length;

            Assert.AreEqual(expected, actual);
        }
    }
}
