using System.Collections.Generic;

namespace FastFoodOnline.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public IEnumerable<Payment> Payments { get; set; }

        public PaymentMethod()
        {
            Payments = new HashSet<Payment>();
        }
    }
}
