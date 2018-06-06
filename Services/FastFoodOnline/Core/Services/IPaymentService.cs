using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Services;
using FastFoodOnline.Models;

namespace FastFoodOnline.Core.Services
{
    public interface IPaymentService : IBaseService
    {
        /// <summary>
        /// Get Payment By User Id - Async
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>IEnumerable of Payment</returns>
        Task<IEnumerable<Payment>> GetPaymentByUserIdAsync(int userId);

        /// <summary>
        /// Get Payment By Id - Async
        /// </summary>
        /// <param name="id">Payment Id</param>
        /// <returns>Payment</returns>
        Task<Payment> GetPaymentByIdAsync(int id);

        /// <summary>
        /// Add Payment - Async
        /// </summary>
        /// <param name="payment">New Payment</param>
        /// <returns>Added Payment</returns>
        Task<Payment> AddPaymentAsync(Payment payment);
    }
}
