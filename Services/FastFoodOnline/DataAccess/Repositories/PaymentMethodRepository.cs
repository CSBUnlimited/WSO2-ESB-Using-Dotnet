using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Base.Repositories;
using FastFoodOnline.Core.DataAccess.Repositories;
using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodOnline.DataAccess.Repositories
{
    /// <summary>
    /// PaymentMethod related data
    /// </summary>
    public class PaymentMethodRepository : BaseRepository, IPaymentMethodRepository
    {
        /// <summary>
        /// Get All Payment Methods - Async
        /// </summary>
        /// <returns>IEnumerable of PaymentMethod</returns>
        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodsAsync()
        {
            return await DbContext.PaymentMethods.ToListAsync();
        }

        /// <summary>
        /// Get Payment Method By Id - Async
        /// </summary>
        /// <param name="id">Payment Method Id</param>
        /// <returns>PaymentMethod</returns>
        public async Task<PaymentMethod> GetPaymentMethodByIdAsync(int id)
        {
            return await DbContext.PaymentMethods.SingleOrDefaultAsync(pm => pm.Id == id);
        }

        /// <summary>
        /// Get Payment Method By Code - Async
        /// </summary>
        /// <param name="code">Payment Method Code</param>
        /// <returns>PaymentMethod</returns>
        public async Task<PaymentMethod> GetPaymentMethodByCodeAsync(string code)
        {
            return await DbContext.PaymentMethods.SingleOrDefaultAsync(pm => pm.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
