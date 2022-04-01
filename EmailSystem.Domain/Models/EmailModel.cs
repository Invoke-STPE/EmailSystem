using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSystem.Domain.Models
{
    public class EmailModel
    {
        private string id; // ID's should not be used for querying.

        public string SenderID { get; set; }
        public ApplicationUser Sender { get; set; }
        public string RecipientId { get; set; }
        public ApplicationUser Recipient { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }

        public EmailModel()
        {
            id = Guid.NewGuid().ToString("D");
            SentDate = DateTime.Now;
        }

        public string GetMessageTeaser()
        {
            if (!string.IsNullOrWhiteSpace(Message) && Message.Length >= 10) 
            {
                return Message.Substring(0, 10);
            }
            return "";
        }

        public string GetFullName()
        {
            return null;
        }

        public override bool Equals(object obj)
        {
            return obj is EmailModel model &&
                   id == model.id &&
                   SenderID == model.SenderID &&
                   EqualityComparer<ApplicationUser>.Default.Equals(Sender, model.Sender) &&
                   RecipientId == model.RecipientId &&
                   EqualityComparer<ApplicationUser>.Default.Equals(Recipient, model.Recipient) &&
                   Subject == model.Subject &&
                   Message == model.Message &&
                   SentDate == model.SentDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, SenderID, Sender, RecipientId, Recipient, Subject, Message, SentDate);
        }
    }
}
