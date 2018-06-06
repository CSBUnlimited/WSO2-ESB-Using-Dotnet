using FastFoodOnline.Base.DTOs;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Resources.DTOs.Payment
{
    public class PaymentRequest : BaseRequest
    {
        public PaymentViewModel PaymentViewModel { get; set; }
    }
}
