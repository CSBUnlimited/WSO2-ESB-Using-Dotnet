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

        Task<int> Complete();
        Task<IDbContextTransaction> BeginTransaction();
    }
}
