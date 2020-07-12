using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManager.Data.DbContexts;
using AccountManager.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace AccountManager.Data.DbHandlers
{
    /// <summary>
    /// Implementation for <see cref="IAccountDbHandler"/>
    /// </summary>
    public class AccountDbHandler : IAccountDbHandler
    {
        #region Fields

        private readonly SqliteDbContext dbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountDbHandler"/> class.
        /// </summary>
        /// <param name="sqliteDbContext">
        /// The dbContext
        /// </param>
        public AccountDbHandler(SqliteDbContext sqliteDbContext)
        {
            dbContext = sqliteDbContext;
        }

        #endregion

        #region Public Methods

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await Task.FromResult(dbContext.Accounts.Where(a => a.IsActive));
        }

        public async Task<IEnumerable<Account>> GetUserAccountsAsync(int userId)
        {
            return await Task.FromResult(dbContext.Accounts.Include("User").Where(a => a.User.Id == userId && a.IsActive));
        }

        public async Task<Account> GetAccountAsync(int id)
        {
            return await Task.FromResult(dbContext.Accounts.FirstOrDefault(a => a.Id == id && a.IsActive));
        }

        public async Task AddAccountAsync(Account account)
        {
            dbContext.Accounts.Add(account);

            await dbContext.SaveChangesAsync();
        }

        #endregion
    }
}