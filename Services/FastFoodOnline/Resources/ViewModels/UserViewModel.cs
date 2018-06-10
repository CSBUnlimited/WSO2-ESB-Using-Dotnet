using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastFoodOnline.Resources.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [MinLength(6)]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MinLength(5)]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        public string Mobile { get; set; }
        [Required]
        [StringLength(1)]
        public string Gender { get; set; }
        public float LoyaltyPoints { get; set; }
        public DateTime RegisteredDate { get; set; }

        public IEnumerable<PaymentViewModel> PaymentViewModels { get; set; }
        public IEnumerable<SentEmailViewModel> SentEmailViewModels { get; set; }
        public IEnumerable<SentMessageViewModel> SentMessageViewModel { get; set; }
    }
}
