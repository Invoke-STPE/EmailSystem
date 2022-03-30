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
        public string FirstName { get; set; } = default;
        public string LastName { get; set; } = default;
        public ICollection<EmailModel> SentEmails { get; set; } = new List<EmailModel>();
        public ICollection<EmailModel> ReceivedEmails { get; set; } = new List<EmailModel>();
        public ApplicationUser()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is ApplicationUser user &&
                   Id == user.Id &&
                   UserName == user.UserName &&
                   NormalizedUserName == user.NormalizedUserName &&
                   Email == user.Email &&
                   NormalizedEmail == user.NormalizedEmail &&
                   EmailConfirmed == user.EmailConfirmed &&
                   PasswordHash == user.PasswordHash &&
                   SecurityStamp == user.SecurityStamp &&
                   ConcurrencyStamp == user.ConcurrencyStamp &&
                   PhoneNumber == user.PhoneNumber &&
                   PhoneNumberConfirmed == user.PhoneNumberConfirmed &&
                   TwoFactorEnabled == user.TwoFactorEnabled &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(LockoutEnd, user.LockoutEnd) &&
                   LockoutEnabled == user.LockoutEnabled &&
                   AccessFailedCount == user.AccessFailedCount &&
                   FirstName == user.FirstName &&
                   LastName == user.LastName &&
                   EqualityComparer<ICollection<EmailModel>>.Default.Equals(SentEmails, user.SentEmails) &&
                   EqualityComparer<ICollection<EmailModel>>.Default.Equals(ReceivedEmails, user.ReceivedEmails);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(UserName);
            hash.Add(NormalizedUserName);
            hash.Add(Email);
            hash.Add(NormalizedEmail);
            hash.Add(EmailConfirmed);
            hash.Add(PasswordHash);
            hash.Add(SecurityStamp);
            hash.Add(ConcurrencyStamp);
            hash.Add(PhoneNumber);
            hash.Add(PhoneNumberConfirmed);
            hash.Add(TwoFactorEnabled);
            hash.Add(LockoutEnd);
            hash.Add(LockoutEnabled);
            hash.Add(AccessFailedCount);
            hash.Add(FirstName);
            hash.Add(LastName);
            hash.Add(SentEmails);
            hash.Add(ReceivedEmails);
            return hash.ToHashCode();
        }
    }
}