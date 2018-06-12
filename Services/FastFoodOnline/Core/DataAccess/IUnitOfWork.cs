using System.Threading.Tasks;
using FastFoodOnline.Core.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace FastFoodOnline.Core.DataAccess
{
    /// <summary>
    /// Repository data collection - Interface
    /// </summary>
    public interface IUnitOfWork
    {
        #region Repositories

        /// <summary>
        /// Food related data
        /// </summary>
        IFoodRepository FoodRepository { get; }
        /// <summary>
        /// Payment related data
        /// </summary>
        IPaymentRepository PaymentRepository { get; }
        /// <summary>
        /// User related data
        /// </summary>
        IUserRepository UserRepository { get; }
        /// <summary>
        /// PaymentMethod related data
        /// </summary>
        IPaymentMethodRepository PaymentMethodRepository { get; }
        /// <summary>
        /// SentEmail related data
        /// </summary>
        ISentEmailRepository SentEmailRepository { get; }
        /// <summary>
        /// SentMessage related data
        /// </summary>
        ISentMessageRepository SentMessageRepository { get; }
        /// <summary>
        /// Authorization related data
        /// </summary>
        IAuthorizationRepository AuthorizationRepository { get; }

        #endregion

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
