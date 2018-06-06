using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodOnline.Core.Base.Repositories;
using FastFoodOnline.Models;

namespace FastFoodOnline.Core.DataAccess.Repositories
{
    public interface ISentMessageRepository : IBaseRepository
    {
        /// <summary>
        /// Get Sent Messages By User Id - Async
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>IEnumerable of SentMessage</returns>
        Task<IEnumerable<SentMessage>> GetSentMessagesByUserIdAsync(int userId);

        /// <summary>
        /// Add Sent Message - Async
        /// </summary>
        /// <param name="sentMessage">S5ent Message</param>
        Task AddSentMessageAsync(SentMessage sentMessage);
    }
}
