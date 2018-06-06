using System;

namespace FastFoodOnline.Models
{
    public class SentMessage
    {
        public int Id { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        public string Message { get; set; }
        public DateTime SentDateTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
