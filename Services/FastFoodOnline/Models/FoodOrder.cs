namespace FastFoodOnline.Models
{
    public class FoodOrder
    {
        public int Id { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; }

        public int Quantity { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
