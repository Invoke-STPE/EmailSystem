using EmailSystem.DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailSystem.BL.Services
{
    public class UserService
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

            var emails = from user in _context.Users
                         .Where(user => user.Email.ToLower() == email.ToLower())
                         .Include(user => user.SentEmails)
                         from emailSent in user.SentEmails
                         select emailSent;

            return emails.ToList();

        }

    }
}
