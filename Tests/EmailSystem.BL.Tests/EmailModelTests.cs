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
        [DataTestMethod]
        [DataRow("This is", 7)]
        [DataRow("T", 1)]
        [DataRow("This is a", 9)]
        public void GetMessageTeaser_StringBelow10_ShouldReturnMessage(string message, int expected)
        {
            EmailModel emailModel = new EmailModel()
            {
                Message = message
            };

            

            string emailMessage = emailModel.GetMessageTeaser();

            int actual = emailMessage.Length;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFullName_ValidFirstAndLastname_ShouldReturnFullName()
        {
            ApplicationUser applicationUser = new ApplicationUser()
            {
                FirstName = "Steven",
                LastName = "Pedersen"
            };
            EmailModel email = new EmailModel()
            {
                Sender = applicationUser
            };

            string expected = "Steven Pedersen";

            string actual = email.GetFullName();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetFullName_NoLastName_ShouldReturnFirstName()
        {
            ApplicationUser applicationUser = new ApplicationUser()
            {
                FirstName = "Steven",
            };
            EmailModel email = new EmailModel()
            {
                Sender = applicationUser
            };

            string expected = "Steven";

            string actual = email.GetFullName();

            Assert.AreEqual(expected, actual);
        }
    }
}
