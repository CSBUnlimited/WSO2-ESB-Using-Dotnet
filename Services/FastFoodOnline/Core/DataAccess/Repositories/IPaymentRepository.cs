using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Repositories;
using FastFoodOnline.Models;

namespace FastFoodOnline.Core.DataAccess.Repositories
{
    /// <summary>
    /// Payment related data - Interface
    /// </summary>
    public interface IPaymentRepository : IBaseRepository
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
        Task AddPaymentAsync(Payment payment);
    }
}
