using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Base.Services;
using FastFoodOnline.Core.DataAccess;
using FastFoodOnline.Core.Services;
using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace FastFoodOnline.Services
{
    public class PaymentService : BaseService, IPaymentService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork Dependancy</param>
        public PaymentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        /// <summary>
        /// Get Payment By User Id - Async
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>IEnumerable of Payment</returns>
        public async Task<IEnumerable<Payment>> GetPaymentByUserIdAsync(int userId)
        {
            return await UnitOfWork.PaymentRepository.GetPaymentByUserIdAsync(userId);
        }

        /// <summary>
        /// Get Payment By Id - Async
        /// </summary>
        /// <param name="id">Payment Id</param>
        /// <returns>Payment</returns>
        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await UnitOfWork.PaymentRepository.GetPaymentByIdAsync(id);
        }

        /// <summary>
        /// Add Payment - Async
        /// </summary>
        /// <param name="payment">New Payment</param>
        /// <param name="username">User who done the payment</param>
        /// <returns>Added Payment</returns>
        public async Task<Payment> AddPaymentAsync(Payment payment, string username)
        {
            using (IDbContextTransaction transaction = await UnitOfWork.BeginTransactionAsync())
            {
                try
                {
                    // need change
                    // Here we need to check the payment referenece from their api

                    User user = await UnitOfWork.UserRepository.GetUserByUsernameAsync(username);
                    if (user == null)
                    {
                        throw new Exception("Invalid user or user not found.");
                    }

                    payment.UserId = user.Id;

                    PaymentMethod paymentMethod = await UnitOfWork.PaymentMethodRepository.GetPaymentMethodByIdAsync(payment.PaymentMethodId);

                    await UnitOfWork.PaymentRepository.AddPaymentAsync(payment);
                    await UnitOfWork.CompleteAsync();
                    
                    user.LoyaltyPoints += payment.EarnedLoyaltyPoints;
                    await UnitOfWork.CompleteAsync();


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
                    return payment;
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
