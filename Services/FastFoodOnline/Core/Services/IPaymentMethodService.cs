﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Services;
using FastFoodOnline.Models;

namespace FastFoodOnline.Core.Services
{
    /// <summary>
    /// PaymentMethod related Services - Interface
    /// </summary>
    public interface IPaymentMethodService : IBaseService
    {
        /// <summary>
        /// Get All Payment Methods - Async
        /// </summary>
        /// <returns>IEnumerable of PaymentMethod</returns>
        Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodsAsync();
    }
}
