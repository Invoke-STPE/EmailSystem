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

        public IList<EmailModel> GetSentMails(string email)
        {
            ApplicationUser user = Read(email);

            //return _context.Users.Include(user => user).ThenInclude(user => user.SentEmails).ToList();
            var Emails = _context.Users.Include(user => user.SentEmails).ToList();
            return new List<EmailModel>();
        }
    }
}
