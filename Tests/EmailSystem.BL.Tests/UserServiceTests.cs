using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using EmailSystem.DL.Models;
using Microsoft.EntityFrameworkCore;
using EmailSystem.BL.Services;
using EmailSystem.BL.Tests.Helpers;
using System.Linq;

namespace EmailSystem.BL.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private ApplicationDbContext _context;
        private UserService _userService;
        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                       .UseInMemoryDatabase(Guid.NewGuid().ToString()).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                       .Options;
            _context = new ApplicationDbContext(options);
            LoadDatabase.LoadData(_context);
            _userService = new UserService(_context);
            

        }

        [DataTestMethod]
        [DataRow("Steven@email.com")]
        [DataRow("Mike@email.com")]
        [DataRow("steven@email.com")]
        [DataRow("mike@email.com")]
        [DataRow("STEVEN@email.com")]
        [DataRow("MIKE@email.com")]
        public void Read_ValidEmail_ShouldReturnCorrectEntity(string email)
        {
            // Arrange
            string expected = email;

            ApplicationUser user = _userService.Read(email);

            string actual = user.Email;
            Assert.AreEqual(expected.ToLower(), actual.ToLower());
        }
        [DataTestMethod]
        [DataRow("Steen@email.com")]
        [DataRow("Mke@email.com")]
        [DataRow("Mike@gmail.com")]
        [DataRow("Steven@gmail.com")]
        public void Read_InvalidEmail_ShouldReturnNull(string email)
        {

            ApplicationUser applicationUser = _userService.Read(email);

            Assert.IsNull(applicationUser);
        }

        [DataTestMethod]
        [DataRow("Steven@email.com", 2)]
        [DataRow("steven@email.com", 2)]
        [DataRow("Mike@email.com", 1)]
        [DataRow("mike@email.com", 1) ]
        public void GetSentMails_ReturnsAllSentMails(string email, int expectedValue)
        {
            int expected = expectedValue;

            List<EmailModel> emails = _userService.GetSentMails(email).ToList();

            int actual = emails.Count;
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("Steen@email.com")]
        [DataRow("Mke@email.com")]
        [DataRow("Mike@gmail.com")]
        [DataRow("Steven@gmail.com")]
        public void GetSentMails_InvalidEmail_ReturnsZero(string email)
        {
            int expected = 0;

            List<EmailModel> emails = _userService.GetSentMails(email).ToList();

            int actual = emails.Count;
            Assert.AreEqual(expected, actual);
        }


        [DataTestMethod]
        [DataRow("Steven@email.com", 1)]
        [DataRow("steven@email.com", 1)]
        [DataRow("Mike@email.com", 2)]
        [DataRow("mike@email.com", 2)]
        public void GetReceivedMails_ReturnsAllReceivedMails(string email, int expectedValue)
        {
            int expected = expectedValue;

            List<EmailModel> emails = _userService.GetReceivedMails(email).ToList();

            int actual = emails.Count;
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("Steen@email.com")]
        [DataRow("Mke@email.com")]
        [DataRow("Mike@gmail.com")]
        [DataRow("Steven@gmail.com")]
        public void GetReceivedMails_InvalidEmail_ReturnsZero(string email)
        {
            int expected = 0;

            List<EmailModel> emails = _userService.GetSentMails(email).ToList();

            int actual = emails.Count;
            Assert.AreEqual(expected, actual);
        }

    }
}
