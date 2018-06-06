using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodOnline.Base.Repositories;
using FastFoodOnline.Core.DataAccess.Repositories;
using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodOnline.DataAccess.Repositories
{
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        /// <summary>
        /// Get Payment By User Id - Async
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>IEnumerable of Payment</returns>
        public async Task<IEnumerable<Payment>> GetPaymentByUserIdAsync(int userId)
        {
            return await DbContext.Payments
                .Include(p => p.PaymentMethod)
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        /// <summary>
        /// Get Payment By Id - Async
        /// </summary>
        /// <param name="id">Payment Id</param>
        /// <returns>Payment</returns>
        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await DbContext.Payments
                .Include(p => p.FoodOrders)
                .Include(p => p.PaymentMethod)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Add Payment - Async
        /// </summary>
        /// <param name="payment">New Payment</param>
        public async Task AddPaymentAsync(Payment payment)
        {
            await DbContext.Payments.AddAsync(payment);
        }
    }
}
