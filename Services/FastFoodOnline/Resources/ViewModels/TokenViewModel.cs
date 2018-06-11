using System;

namespace FastFoodOnline.Resources.ViewModels
{
    public class TokenViewModel
    {
        public string TokenString { get; set; }
        public DateTime IssuedDateTime { get; set; }
        public DateTime ExpireDateTime { get; set; }
    }
}
