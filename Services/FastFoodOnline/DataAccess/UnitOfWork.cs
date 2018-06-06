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

        private readonly FastFoodDbContext _fastFoodDbContext;

        #endregion

        #region Repositories

        public IFoodRepository FoodRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IUserRepository UserRepository { get; }
        public IPaymentMethodRepository PaymentMethodRepository { get; }
        public ISentEmailRepository SentEmailRepository { get; }
        public ISentMessageRepository SentMessageRepository { get; }

        #endregion

        public UnitOfWork
        (
            FastFoodDbContext fastFoodDbContext,
            IFoodRepository foodRepository,
            IPaymentRepository paymentRepository,
            IUserRepository userRepository,
            IPaymentMethodRepository paymentMethodRepository,
            ISentEmailRepository sentEmailRepository,
            ISentMessageRepository sentMessageRepository
        )
        {
            _fastFoodDbContext = fastFoodDbContext;

            FoodRepository = foodRepository;
            PaymentRepository = paymentRepository;
            UserRepository = userRepository;
            PaymentMethodRepository = paymentMethodRepository;
            SentEmailRepository = sentEmailRepository;
            SentMessageRepository = sentMessageRepository;

            //Setup the DbContext
            FoodRepository.DbContext = _fastFoodDbContext;
            PaymentRepository.DbContext = _fastFoodDbContext;
            UserRepository.DbContext = _fastFoodDbContext;
            PaymentMethodRepository.DbContext = _fastFoodDbContext;
            SentEmailRepository.DbContext = _fastFoodDbContext;
            SentMessageRepository.DbContext = _fastFoodDbContext;
        }

        public async Task<int> Complete()
        {
            return await _fastFoodDbContext.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _fastFoodDbContext.Database.BeginTransactionAsync();
        }
    }
}
