using FastFoodOnline.Base.DTOs;

namespace FastFoodOnline.Resources.DTOs.Login
{
    public class LoginRequest : BaseRequest
    {
        public string Password { get; set; }
    }
}
