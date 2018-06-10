using System.Threading.Tasks;
using FastFoodOnline.Core.DataAccess;
using FastFoodOnline.Core.DataAccess.Repositories;
using FastFoodOnline.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace FastFoodOnline.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Properties

        /// <summary>
        /// FastFood DbContext
        /// </summary>
        private readonly FastFoodDbContext _fastFoodDbContext;

        #endregion

        #region Repositories

        public IFoodRepository FoodRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IUserRepository UserRepository { get; }
        public IPaymentMethodRepository PaymentMethodRepository { get; }
        public ISentEmailRepository SentEmailRepository { get; }
        public ISentMessageRepository SentMessageRepository { get; }
        public IAuthorizationRepository AuthorizationRepository { get; }

        #endregion

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

            //Setup the DbContext
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
