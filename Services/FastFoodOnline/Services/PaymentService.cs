using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodOnline.Base.Services;
using FastFoodOnline.Core.DataAccess;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;
using FastFoodOnline.Resources.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;

namespace FastFoodOnline.Services
{
    /// <summary>
    /// Payment related Services
    /// </summary>
    public class PaymentService : BaseService, IPaymentService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        /// <param name="mapper">Auto Mapper Injection</param>
        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        { }

        /// <summary>
        /// Get Payment By User Id - Async
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>IEnumerable of PaymentViewModel</returns>
        public async Task<IEnumerable<PaymentViewModel>> GetPaymentViewModelsByUserIdAsync(int userId)
        {
            return Mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentViewModel>>(await UnitOfWork.PaymentRepository.GetPaymentByUserIdAsync(userId));
        }

        /// <summary>
        /// Get Payment By Id - Async
        /// </summary>
        /// <param name="id">Payment Id</param>
        /// <returns>PaymentViewModel</returns>
        public async Task<PaymentViewModel> GetPaymentViewModelByIdAsync(int id)
        {
            return Mapper.Map<Payment, PaymentViewModel>(await UnitOfWork.PaymentRepository.GetPaymentByIdAsync(id));
        }

        /// <summary>
        /// Add Payment - Async
        /// </summary>
        /// <param name="paymentViewModel">New PaymentViewModel</param>
        /// <returns>Added Payment</returns>
        public async Task<PaymentViewModel> AddPaymentViewModelAsync(PaymentViewModel paymentViewModel)
        {
            using (IDbContextTransaction transaction = await UnitOfWork.BeginTransactionAsync())
            {
                try
                {
                    // need change
                    // Here we need to check the payment referenece from their api

                    string username = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                    User user = await UnitOfWork.UserRepository.GetUserByUsernameAsync(username);
                    if (user == null)
                    {
                        throw new Exception("Invalid user or user not found.");
                    }

                    PaymentMethod paymentMethod = await UnitOfWork.PaymentMethodRepository.GetPaymentMethodByCodeAsync(paymentViewModel.PaymentMethodCode);
                    if (paymentMethod == null)
                    {
                        throw new Exception("Invalid payment method code.");
                    }

                    Payment payment = Mapper.Map<PaymentViewModel, Payment>(paymentViewModel);

                    // Set Payment's missing parts
                    payment.UserId = user.Id;
                    payment.PaymentMethodId = paymentMethod.Id;

                    await UnitOfWork.PaymentRepository.AddPaymentAsync(payment);

                    //Update user's loyalty points
                    user.LoyaltyPoints += payment.EarnedLoyaltyPoints;

                    string message = $"{ ((user.Gender == Gender.Male) ? "Mr" : "Miss/ Mrs") }. { user.FirstName }, you payed Rs.{ string.Format("{0:0.00}", payment.Amount) } successfully by { paymentMethod.Name } on { payment.PayedDateTime }";

                    SentEmail sentEmail = new SentEmail()
                    {
                        Subject = "Payment success",
                        Message = message,
                        Payment = payment,
                        UserId = user.Id
                    };
                    //Do what ever thing in here to send email
                    await UnitOfWork.SentEmailRepository.AddSentEmailAsync(sentEmail);

                    SentMessage sentMessage = new SentMessage()
                    {
                        Message = message,
                        Payment = payment,
                        UserId = user.Id
                    };
                    //Do what ever thing in here to send sms
                    await UnitOfWork.SentMessageRepository.AddSentMessageAsync(sentMessage);

                    await UnitOfWork.CompleteAsync();
                    transaction.Commit();

                    payment.PaymentMethod = paymentMethod;

                    // Create new Payment ViewModel
                    PaymentViewModel addedPaymentViewModel = Mapper.Map<Payment, PaymentViewModel>(payment);
                    addedPaymentViewModel.PaymentMethodCode = paymentMethod.Code;

                    return addedPaymentViewModel;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
