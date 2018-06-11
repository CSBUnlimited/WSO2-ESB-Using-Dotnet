using System.ComponentModel.DataAnnotations;
using FastFoodOnline.Base.DTOs;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Resources.DTOs.Payment
{
    public class PaymentRequest : BaseRequest
    {
        [Required]
        public PaymentViewModel PaymentViewModel { get; set; }
    }
}
