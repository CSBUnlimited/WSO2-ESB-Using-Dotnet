using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodOnline.Base.Services;
using FastFoodOnline.Core.DataAccess;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;

namespace FastFoodOnline.Services
{
    /// <summary>
    /// PaymentMethod related Services
    /// </summary>
    public class PaymentMethodService : BaseService, IPaymentMethodService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        /// <param name="mapper">Auto Mapper Injection</param>
        public PaymentMethodService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
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
