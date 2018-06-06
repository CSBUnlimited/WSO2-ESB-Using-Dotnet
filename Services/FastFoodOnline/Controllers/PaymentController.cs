using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;
using FastFoodOnline.Resources.DTOs.Payment;
using FastFoodOnline.Resources.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodOnline.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaymentController : ControllerBase
    {
        #region Private Properties

        private readonly IPaymentService _paymentService;
        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="paymentService">PaymentService</param>
        /// <param name="mapper">Automapper</param>
        public PaymentController(IPaymentService paymentService, IAuthenticateService authenticateService, IMapper mapper)
        {
            _paymentService = paymentService;
            _authenticateService = authenticateService;
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
                    User user = await _authenticateService.AuthenticateUsernameAsync(paymentRequest.Username);

                    if (user == null || user.Id <= 0)
                    {
                        paymentResponse.Status = (int)HttpStatusCode.Unauthorized;
                        throw new Exception("Unauthorized user");
                    }

                    Payment payment = _mapper.Map<PaymentViewModel, Payment>(paymentRequest.PaymentViewModel);
                    payment.UserId = user.Id;

                    payment = await _paymentService.AddPaymentAsync(payment);

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