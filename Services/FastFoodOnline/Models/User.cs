using System;
using System.Collections.Generic;

namespace FastFoodOnline.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public float LoyaltyPoints { get; set; }
        public DateTime RegisteredDate { get; set; }

        public bool? IsActive { get; set; }
        
        public IEnumerable<Payment> Payments { get; set; }
        public IEnumerable<SentEmail> SentEmails { get; set; }
        public IEnumerable<SentMessage> SentMessages { get; set; }

        public User()
        {
            Payments = new HashSet<Payment>();
            SentEmails = new HashSet<SentEmail>();
            SentMessages = new HashSet<SentMessage>();
        }
    }

    public enum Gender : byte
    {
        Male = 0,
        Female = 1
    }
}
