using System.Collections.Generic;
using FastFoodOnline.Base.DTOs;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Resources.DTOs.User
{
    public class UserResponse : BaseResponse
    {
        public IEnumerable<UserViewModel> UserViewModels { get; set; }
    }
}
