using FastFoodOnline.Base.DTOs;

namespace FastFoodOnline.Resources.DTOs.Authentication
{
    public class AuthenticationResponse : BaseResponse
    {
        public string AuthenticationToken { get; set; }
    }
}
