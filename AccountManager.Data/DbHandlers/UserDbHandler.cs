using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManager.Data.DbContexts;
using AccountManager.Data.Models;

namespace AccountManager.Data.DbHandlers
{
    /// <summary>
    /// The implementation for <see cref="IUserDbHandler"/>
    /// </summary>
    public class UserDbHandler : IUserDbHandler
    {
        #region Fields

        private readonly SqliteDbContext dbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDbHandler"/> class.
        /// </summary>
        /// <param name="sqliteDbContext">
        /// The dbContext
        /// </param>
        public UserDbHandler(SqliteDbContext sqliteDbContext)
        {
            dbContext = sqliteDbContext;
        }

        #endregion

        #region Public methods

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await Task.FromResult(dbContext.Users);
        }

        public async Task AddUserAsync(User user)
        {
            dbContext.Users.Add(user);

            await dbContext.SaveChangesAsync();
        }

        #endregion
    }
}