using System.Collections.Generic;
using FastFoodOnline.Base.DTOs;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Resources.DTOs.Payment
{
    public class PaymentResponse : BaseResponse
    {
        public IEnumerable<PaymentViewModel> PaymentViewModels { get; set; }
    }
}
