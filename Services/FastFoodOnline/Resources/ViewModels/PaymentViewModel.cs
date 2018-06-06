using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastFoodOnline.Resources.ViewModels
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        [Required]
        public int PaymentMethodId { get; set; }
        [Required]
        public string ReferenceNumber { get; set; }
        public PaymentMethodViewModel PaymentMethodViewModel { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public float EarnedLoyaltyPoints { get; set; }
        [Required]
        public IEnumerable<FoodOrderViewModel> FoodOrderViewModels { get; set; }
    }
}
