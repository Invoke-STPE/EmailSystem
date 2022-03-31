using EmailSystem.Domain.Models;
using System.Collections.Generic;

namespace EmailSystem.BL.Services
{
    public interface IUserService
    {
        ICollection<EmailModel> GetReceivedMails(string email);
        ICollection<EmailModel> GetSentMails(string email);
        ApplicationUser Read(string email);
        void SendEmail(string senderEmail, string recipentEmail, EmailModel email);
    }
}