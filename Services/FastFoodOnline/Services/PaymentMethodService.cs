using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Base.Services;
using FastFoodOnline.Core.DataAccess;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;

namespace FastFoodOnline.Services
{
    public class PaymentMethodService : BaseService, IPaymentMethodService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        public PaymentMethodService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        /// <summary>
        /// Get All Payment Methods - Async
        /// </summary>
        /// <returns>IEnumerable of PaymentMethod</returns>
        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodsAsync()
        {
            return await UnitOfWork.PaymentMethodRepository.GetAllPaymentMethodsAsync();
        }
    }
}
