using System;
using System.Collections.Generic;

namespace FastFoodOnline.Models
{
    /// <summary>
    /// Payment Model
    /// </summary>
    public class Payment
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string ReferenceNumber { get; set; }

        public float Amount { get; set; }
        public float EarnedLoyaltyPoints { get; set; }
        public DateTime PayedDateTime { get; set; }


        public SentEmail SentEmail { get; set; }
        public SentMessage SentMessage { get; set; }

        public IEnumerable<FoodOrder> FoodOrders { get; set; }

        public Payment()
        {
            FoodOrders = new HashSet<FoodOrder>();
        }
    }
}
