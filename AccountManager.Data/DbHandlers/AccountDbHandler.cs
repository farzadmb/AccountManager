using AccountManager.Data.DbContexts;
using AccountManager.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// The default constructor
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

        public IEnumerable<Account> GetAccounts()
        {
            return dbContext.Accounts.Where(a => a.IsActive);
        }

        public IEnumerable<Account> GetUserAccounts(int userId)
        {
            return dbContext.Accounts.Where(a => a.User.Id == userId && a.IsActive);
        }

        public Account GetAccount(int id)
        {
            return dbContext.Accounts.FirstOrDefault(a => a.Id == id && a.IsActive);
        }

        public async Task AddAccount(Account account)
        {
            dbContext.Accounts.Add(account);

            await dbContext.SaveChangesAsync();
        }

        #endregion
    }
}