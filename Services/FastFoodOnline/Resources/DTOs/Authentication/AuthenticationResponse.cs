using FastFoodOnline.Base.DTOs;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Resources.DTOs.Authentication
{
    public class AuthenticationResponse : BaseResponse
    {
        public TokenViewModel TokenViewModel { get; set; }
    }
}
