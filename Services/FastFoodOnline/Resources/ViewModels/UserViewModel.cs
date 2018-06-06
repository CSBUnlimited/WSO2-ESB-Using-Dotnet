using System;
using System.Collections.Generic;

namespace FastFoodOnline.Resources.ViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public float LoyaltyPoints { get; set; }
        public DateTime RegisteredDate { get; set; }

        public IEnumerable<PaymentViewModel> PaymentViewModels { get; set; }
        public IEnumerable<SentEmailViewModel> SentEmailViewModels { get; set; }
        public IEnumerable<SentMessageViewModel> SentMessageViewModel { get; set; }
    }
}
