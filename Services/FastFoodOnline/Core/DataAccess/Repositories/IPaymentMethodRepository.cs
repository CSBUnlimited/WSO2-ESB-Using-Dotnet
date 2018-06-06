using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Repositories;
using FastFoodOnline.Models;

namespace FastFoodOnline.Core.DataAccess.Repositories
{
    public interface IPaymentMethodRepository : IBaseRepository
    {
        /// <summary>
        /// Get All Payment Methods - Async
        /// </summary>
        /// <returns>IEnumerable of PaymentMethod</returns>
        Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodsAsync();

        /// <summary>
        /// Get Payment Method By Id - Async
        /// </summary>
        /// <param name="id">Payment Method Id</param>
        /// <returns>PaymentMethod</returns>
        Task<PaymentMethod> GetPaymentMethodByIdAsync(int id);

        /// <summary>
        /// Get Payment Method By Code - Async
        /// </summary>
        /// <param name="code">Payment Method Code</param>
        /// <returns>PaymentMethod</returns>
        Task<PaymentMethod> GetPaymentMethodByCodeAsync(string code);
    }
}
