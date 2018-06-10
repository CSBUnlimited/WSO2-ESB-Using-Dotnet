using System.Threading.Tasks;
using FastFoodOnline.Core.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace FastFoodOnline.Core.DataAccess
{
    public interface IUnitOfWork
    {
        IFoodRepository FoodRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IUserRepository UserRepository { get; }
        IPaymentMethodRepository PaymentMethodRepository { get; }
        ISentEmailRepository SentEmailRepository { get; }
        ISentMessageRepository SentMessageRepository { get; }
        IAuthorizationRepository AuthorizationRepository { get; }

        /// <summary>
        /// Same meaning as Save Chnages - Async
        /// </summary>
        /// <returns>Rows count affected</returns>
        Task<int> CompleteAsync();

        /// <summary>
        /// Creating Transaction - Async
        /// </summary>
        /// <returns>IDbContextTransaction</returns>
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
