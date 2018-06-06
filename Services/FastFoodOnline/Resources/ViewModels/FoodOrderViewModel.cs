using System.ComponentModel.DataAnnotations;

namespace FastFoodOnline.Resources.ViewModels
{
    public class FoodOrderViewModel
    {
        [Required]
        public int FoodId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
