using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSystem.DL.Models
{
    internal class EmailModel
    {
        private string id; // ID's should not be used for querying.

        public string SenderID { get; set; }
        public UserModel Sender { get; set; }
        public string RecipientId { get; set; }
        public UserModel Recipient { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }

        public EmailModel()
        {
            id = Guid.NewGuid().ToString("D");
        }
    }
}
