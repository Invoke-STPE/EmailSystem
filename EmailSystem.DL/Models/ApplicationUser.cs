using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace EmailSystem.DL.Models
{
    /// <summary>
    /// Still need to create a config, initialize properties and so on
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<EmailModel> SentEmails { get; set; }
        public ICollection<EmailModel> ReceivedEmails { get; set; }
        public ApplicationUser()
        {
        }
    }
}