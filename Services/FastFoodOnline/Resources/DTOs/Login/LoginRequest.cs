using System.ComponentModel.DataAnnotations;
using FastFoodOnline.Base.DTOs;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Resources.DTOs.Login
{
    public class LoginRequest : BaseRequest
    {
        [Required]
        public LoginViewModel LoginViewModel { get; set; }
    }
}
