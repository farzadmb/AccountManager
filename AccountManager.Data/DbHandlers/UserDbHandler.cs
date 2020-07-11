using AccountManager.Data.DbContexts;
using AccountManager.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// The default constructor
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

        public IEnumerable<User> GetUsers()
        {
            return dbContext.Users;
        }

        public User GetUser(int userId)
        {
            return dbContext.Users.FirstOrDefault(u => u.Id == userId);
        }

        public User GetUser(string email)
        {
            return dbContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            dbContext.Users.Add(user);

            await dbContext.SaveChangesAsync();
        }

        #endregion
    }
}