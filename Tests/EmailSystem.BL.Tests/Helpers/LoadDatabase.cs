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

            ApplicationUser userSteven = new ApplicationUser()
            {
                Email = "Steven@email.com",
                FirstName = "Steven",
                LastName = "Pedersen",
                SentEmails = new List<EmailModel>()
                {
                     new EmailModel()
                     {
                            Message = "This is a test message sent to Mike",
                            SentDate = DateTime.Now
                     },
                     new EmailModel()
                     {
                            Message = "This is a test message 2 sent to Mike",
                            SentDate = DateTime.Now
                     }
                },
                ReceivedEmails = new List<EmailModel>()
                {
                    new EmailModel()
                    {
                        Message = "This is a test message sent to Steven",
                        SentDate = DateTime.Now
                    }
                }
            };
            ApplicationUser userMike = new ApplicationUser()
            {
                Email = "Mike@email.com",
                FirstName = "Mike",
                LastName = "Brandt",
                SentEmails = new List<EmailModel>()
                {
                    new EmailModel()
                    {
                        Message = "This is a test message sent to Steven",
                        SentDate = DateTime.Now
                    }
                },
                ReceivedEmails = new List<EmailModel>()
                {
                    new EmailModel()
                     {
                            Message = "This is a test message sent to Mike",
                            
                     },
                     new EmailModel()
                     {
                            Message = "This is a test message 2 sent to Mike",
                            
                     }
                }
            };

            context.Users.AddRange(userSteven, userMike);

            context.SaveChanges();
        }
    }
}
