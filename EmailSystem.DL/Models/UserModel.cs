using System;
using System.Collections.Generic;

namespace EmailSystem.DL.Models
{
    /// <summary>
    /// Still need to create a config, initialize properties and so on
    /// </summary>
    internal class UserModel
    {
        private string id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<EmailModel> Emails { get; set; }
        public UserModel()
        {
            id = Guid.NewGuid().ToString("D");
        }
    }
}