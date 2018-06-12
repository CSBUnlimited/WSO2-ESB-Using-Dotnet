using System.Threading.Tasks;
using FastFoodOnline.Core.DataAccess;
using FastFoodOnline.Core.DataAccess.Repositories;
using FastFoodOnline.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace FastFoodOnline.DataAccess
{
    /// <summary>
    /// Repository data collection
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Properties

        /// <summary>
        /// FastFood DbContext
        /// </summary>
        private readonly FastFoodDbContext _fastFoodDbContext;

        #endregion

        #region Repositories

        /// <summary>
        /// Food related data
        /// </summary>
        public IFoodRepository FoodRepository { get; }
        /// <summary>
        /// Payment related data
        /// </summary>
        public IPaymentRepository PaymentRepository { get; }
        /// <summary>
        /// User related data
        /// </summary>
        public IUserRepository UserRepository { get; }
        /// <summary>
        /// PaymentMethod related data
        /// </summary>
        public IPaymentMethodRepository PaymentMethodRepository { get; }
        /// <summary>
        /// SentEmail related data
        /// </summary>
        public ISentEmailRepository SentEmailRepository { get; }
        /// <summary>
        /// SentMessage related data
        /// </summary>
        public ISentMessageRepository SentMessageRepository { get; }
        /// <summary>
        /// Authorization related data
        /// </summary>
        public IAuthorizationRepository AuthorizationRepository { get; }

        #endregion

        /// <summary>
        /// Counstructor
        /// </summary>
        /// <param name="fastFoodDbContext">FastFoodDbContext - Injection</param>
        /// <param name="foodRepository">FoodRepository - Injection</param>
        /// <param name="paymentRepository">PaymentRepository - Injection</param>
        /// <param name="userRepository">UserRepository - Injection</param>
        /// <param name="paymentMethodRepository">PaymentMethodRepository - Injection</param>
        /// <param name="sentEmailRepository">SentEmailRepository - Injection</param>
        /// <param name="sentMessageRepository">SentMessageRepository - Injection</param>
        /// <param name="authorizationRepository">AuthorizationRepository - Injection</param>
        public UnitOfWork
        (
            FastFoodDbContext fastFoodDbContext,
            IFoodRepository foodRepository,
            IPaymentRepository paymentRepository,
            IUserRepository userRepository,
            IPaymentMethodRepository paymentMethodRepository,
            ISentEmailRepository sentEmailRepository,
            ISentMessageRepository sentMessageRepository,
            IAuthorizationRepository authorizationRepository
        )
        {
            _fastFoodDbContext = fastFoodDbContext;

            FoodRepository = foodRepository;
            PaymentRepository = paymentRepository;
            UserRepository = userRepository;
            PaymentMethodRepository = paymentMethodRepository;
            SentEmailRepository = sentEmailRepository;
            SentMessageRepository = sentMessageRepository;
            AuthorizationRepository = authorizationRepository;

            // Setup the DbContext
            FoodRepository.DbContext = _fastFoodDbContext;
            PaymentRepository.DbContext = _fastFoodDbContext;
            UserRepository.DbContext = _fastFoodDbContext;
            PaymentMethodRepository.DbContext = _fastFoodDbContext;
            SentEmailRepository.DbContext = _fastFoodDbContext;
            SentMessageRepository.DbContext = _fastFoodDbContext;
            AuthorizationRepository.DbContext = _fastFoodDbContext;
        }

        /// <summary>
        /// Same meaning as Save Chnages - Async
        /// </summary>
        /// <returns>Rows count affected</returns>
        public async Task<int> CompleteAsync()
        {
            return await _fastFoodDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Creating Transaction - Async
        /// </summary>
        /// <returns>IDbContextTransaction</returns>
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _fastFoodDbContext.Database.BeginTransactionAsync();
        }
    }
}
