using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Repositories;
using FastFoodOnline.Models;

namespace FastFoodOnline.Core.DataAccess.Repositories
{
    public interface ISentEmailRepository : IBaseRepository
    {
        /// <summary>
        /// Add Sent Email - Async
        /// </summary>
        /// <param name="sentEmail"></param>
        Task AddSentEmailAsync(SentEmail sentEmail);

        /// <summary>
        /// Get Sent Emails By User Id - Async
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>IEnumerable of SentEmail</returns>
        Task<IEnumerable<SentEmail>> GetSentEmailsByUserIdAsync(int userId);
    }
}
