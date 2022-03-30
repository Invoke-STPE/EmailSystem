using EmailSystem.DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailSystem.BL.Tests.Helpers
{
    internal static class LoadDatabase
    {
        public static void LoadData(ApplicationDbContext context)
        {

            //context.Users.AddRange(
            //    new ApplicationUser()
            //    {
            //        Email = "Steven@email.com",
            //        FirstName = "Steven",
            //        LastName = "Mike",

            //    },
            //    new ApplicationUser()
            //    {
            //        Email = "Mike@email.com",
            //        FirstName = "Mike",
            //        LastName = "Brandt",
            //    }
            //);

            ApplicationUser userSteven = new ApplicationUser()
            {
                Email = "Steven@email.com",
                FirstName = "Steven",
                LastName = "Mike",

            };
            ApplicationUser userMike = new ApplicationUser()
            {
                Email = "Mike@email.com",
                FirstName = "Mike",
                LastName = "Brandt",
            };

            //context.SaveChanges();

                //ApplicationUser userSteven = context.Users.SingleOrDefault(u => u.Email == "Steven@email.com");
                //ApplicationUser userMike = context.Users.SingleOrDefault(u => u.Email == "Mike@email.com");


            EmailModel email1 = new EmailModel()
            {
                Message = "This is a test message sent to Mike",
                Sender = userSteven,
                Recipient = userMike,
                SentDate = DateTime.Now
            };
            EmailModel email2 = new EmailModel()
            {
                Message = "This is a test message 2 sent to Mike",
                Sender = userSteven,
                Recipient = userMike,
                SentDate = DateTime.Now
            };
            EmailModel email3 = new EmailModel()
            {
                Message = "This is a test message sent to Steven",
                Sender = userMike,
                Recipient = userSteven,
                SentDate = DateTime.Now
            };

            context.Emails.AddRange(email1, email2, email3);

            context.SaveChanges();

            //userSteven.SentEmails.Add(email1);
            //userSteven.SentEmails.Add(email2);

            //userMike.SentEmails.Add(email3);

            //context.SaveChanges();
        }
    }
}
