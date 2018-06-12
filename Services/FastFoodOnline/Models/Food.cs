using System.Collections.Generic;

namespace FastFoodOnline.Models
{
    /// <summary>
    /// Food Model
    /// </summary>
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool? IsActive { get; set; }

        public IEnumerable<FoodOrder> FoodOrders { get; set; }

        public Food()
        {
            FoodOrders = new HashSet<FoodOrder>();
        }
    }
}
