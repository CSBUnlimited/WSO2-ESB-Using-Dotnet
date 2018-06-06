using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodOnline.Base.Repositories;
using FastFoodOnline.Core.DataAccess.Repositories;
using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodOnline.DataAccess.Repositories
{
    public class SentEmailRepository : BaseRepository, ISentEmailRepository
    {
        /// <summary>
        /// Get Sent Emails By User Id - Async
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>IEnumerable of SentEmail</returns>
        public async Task<IEnumerable<SentEmail>> GetSentEmailsByUserIdAsync(int userId)
        {
            return await DbContext.SentEmails.Where(ce => ce.UserId == userId).ToListAsync();
        }

        /// <summary>
        /// Add Sent Email - Async
        /// </summary>
        /// <param name="sentEmail">SentEmail</param>
        public async Task AddSentEmailAsync(SentEmail sentEmail)
        {
            await DbContext.SentEmails.AddAsync(sentEmail);
        }
    }
}
