using EmailSystem.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSystem.Domain.Interfaces
{
    public interface IUserService
    {
        Task<ICollection<EmailModel>> GetReceivedMails(string email);
        ICollection<EmailModel> GetSentMails(string email);
        ApplicationUser Read(string email);
        void SendEmail(string senderEmail, string recipentEmail, EmailModel email);
    }
}