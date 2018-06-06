using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodOnline.Base.Repositories;
using FastFoodOnline.Core.DataAccess.Repositories;
using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodOnline.DataAccess.Repositories
{
    public class SentMessageRepository : BaseRepository, ISentMessageRepository
    {
        /// <summary>
        /// Get Sent Messages By User Id - Async
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>IEnumerable of SentMessage</returns>
        public async Task<IEnumerable<SentMessage>> GetSentMessagesByUserIdAsync(int userId)
        {
            return await DbContext.SentMessages.Where(cs => cs.UserId == userId).ToListAsync();
        }

        /// <summary>
        /// Add Sent Message - Async
        /// </summary>
        /// <param name="sentMessage">S5ent Message</param>
        public async Task AddSentMessageAsync(SentMessage sentMessage)
        {
            await DbContext.SentMessages.AddAsync(sentMessage);
        }
    }
}
