
using EmailSystem.DL.Models;
using EmailSystem.Domain.Models;
using EmailSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystem.BL.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser Read(string email)
        {
            return _context.Users.SingleOrDefault(user => user.Email.ToLower() == email.ToLower());
        }

        public ICollection<EmailModel> GetSentMails(string email)
        {

            var sentEmails = from user in _context.Users
                         .Where(user => user.Email.ToLower() == email.ToLower())
                         .Include(user => user.SentEmails)
                             from emailSent in user.SentEmails
                             select emailSent;

            return sentEmails.ToList();

        }

        public ICollection<EmailModel> GetReceivedMails(string email)
        {
            var user = Read(email);

            var userId = user != null ? user.Id : ""; // Conditional checks if user exists. 
       
                var receivedEmails = from dbEmail in _context.Emails
                             .Where(e => e.RecipientId == userId)
                             .Include(e => e.Sender)
                                     select dbEmail; 

            return receivedEmails.ToList();

        }

        public void SendEmail(string senderEmail, string recipentEmail, string subject, string message)
        {
            
            var recipentUser = Read(recipentEmail);
            var senderUser = Read(senderEmail);
            EmailModel email = new EmailModel()
            {
                Recipient = recipentUser,
                Sender = senderUser,
                RecipientId = recipentUser.Id,
                SenderID = senderUser.Id,
                Subject = subject,
                Message = message
            };



            _context.Emails.Add(email);
            _context.SaveChanges();
        }
    }
}
