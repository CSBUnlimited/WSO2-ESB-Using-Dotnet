using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Services;
using FastFoodOnline.Resources.ViewModels;

namespace FastFoodOnline.Core.Services
{
    /// <summary>
    /// Payment related Services - Interface
    /// </summary>
    public interface IPaymentService : IBaseService
    {
        /// <summary>
        /// Get PaymentViewModels By User Id - Async
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>IEnumerable of PaymentViewModel</returns>
        Task<IEnumerable<PaymentViewModel>> GetPaymentViewModelsByUserIdAsync(int userId);

        /// <summary>
        /// Get PaymentViewModel By Id - Async
        /// </summary>
        /// <param name="id">Payment Id</param>
        /// <returns>PaymentViewModel</returns>
        Task<PaymentViewModel> GetPaymentViewModelByIdAsync(int id);

        /// <summary>
        /// Add Payment - Async
        /// </summary>
        /// <param name="paymentViewModel">New PaymentViewModel</param>
        /// <returns>Added PaymentViewModel</returns>
        Task<PaymentViewModel> AddPaymentViewModelAsync(PaymentViewModel paymentViewModel);
    }
}
