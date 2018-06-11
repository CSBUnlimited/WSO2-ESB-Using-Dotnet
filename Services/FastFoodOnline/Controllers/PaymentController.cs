using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Resources.DTOs.Payment;
using FastFoodOnline.Resources.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodOnline.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaymentController : ControllerBase
    {
        #region Private Properties

        private readonly IPaymentService _paymentService;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor">HttpContextAccessor to Get Token details</param>
        /// <param name="paymentService">PaymentService</param>
        /// <param name="mapper">Automapper</param>
        public PaymentController(IHttpContextAccessor httpContextAccessor, IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _paymentService.HttpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Add Payment - Async
        /// </summary>
        /// <param name="paymentRequest">FromBody - PaymentRequest</param>
        /// <returns>PaymentResponse</returns>
        [HttpPost(Name = "AddPaymentAsync")]
        public async Task<IActionResult> AddPaymentAsync([FromBody]PaymentRequest paymentRequest)
        {
            PaymentResponse paymentResponse = new PaymentResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    paymentResponse.PaymentViewModels = new List<PaymentViewModel>()
                    {
                        await _paymentService.AddPaymentViewModelAsync(paymentRequest.PaymentViewModel)
                    };

                    paymentResponse.IsSuccess = true;
                    paymentResponse.Status = (int)HttpStatusCode.OK;
                }
                else
                {
                    paymentResponse.Message = $"Model Error Count - { ModelState.ErrorCount }";
                    paymentResponse.MessageDetails = ModelState.ToString();
                    paymentResponse.Status = (int)HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                paymentResponse.Message = ex.Message;
                paymentResponse.MessageDetails = ex.ToString();
                paymentResponse.Status = paymentResponse.Status > 0 ? paymentResponse.Status : (int)HttpStatusCode.BadRequest;
            }

            return StatusCode(paymentResponse.Status, paymentResponse);
        }
    }
}