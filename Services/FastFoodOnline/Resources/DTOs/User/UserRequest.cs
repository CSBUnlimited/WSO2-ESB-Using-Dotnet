using System.ComponentModel.DataAnnotations;
using FastFoodOnline.Base.DTOs;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Resources.DTOs.User
{
    public class UserRequest : BaseRequest
    {
        [Required]
        public UserViewModel UserViewModel { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
