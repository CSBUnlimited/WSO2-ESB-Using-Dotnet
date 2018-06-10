using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;
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

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor">HttpContextAccessor to Get Token details</param>
        /// <param name="paymentService">PaymentService</param>
        /// <param name="mapper">Automapper</param>
        public PaymentController(IHttpContextAccessor httpContextAccessor, IPaymentService paymentService, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _paymentService = paymentService;
            _mapper = mapper;
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
                    string username = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    Payment payment = _mapper.Map<PaymentViewModel, Payment>(paymentRequest.PaymentViewModel);

                    payment = await _paymentService.AddPaymentAsync(payment, username);

                    paymentResponse.PaymentViewModels = new List<PaymentViewModel>()
                    {
                        _mapper.Map<Payment, PaymentViewModel>(payment)
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
                paymentResponse.Status = paymentResponse.Status > 0 ? paymentResponse.Status : (int)HttpStatusCode.Conflict;
            }

            return StatusCode(paymentResponse.Status, paymentResponse);
        }
    }
}