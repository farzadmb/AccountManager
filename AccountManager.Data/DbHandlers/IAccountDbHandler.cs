using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManager.Data.Models;

namespace AccountManager.Data.DbHandlers
{
    /// <summary>
    /// The database services for <see cref="Account"/>
    /// </summary>
    public interface IAccountDbHandler
    {
        /// <summary>
        /// Returns the list of accounts
        /// </summary>
        /// <returns>
        /// The list of <see cref="Account"/>
        /// </returns>
        Task<IEnumerable<Account>> GetAccountsAsync();

        /// <summary>
        /// Return an account based on Id
        /// </summary>
        /// <param name="id">
        /// The Id of account
        /// </param>
        /// <returns>
        /// The account
        /// </returns>
        Task<Account> GetAccountAsync(int id);

        /// <summary>
        /// The accounts of a user
        /// </summary>
        /// <param name="userId">
        /// The Id of user
        /// </param>
        /// <returns>
        /// The list of <see cref="Account"/>
        /// </returns>
        Task<IEnumerable<Account>> GetUserAccountsAsync(int userId);

        /// <summary>
        /// Adds an account
        /// </summary>
        /// <param name="account">
        /// The new account
        /// </param>
        /// <returns>
        /// </returns>
        Task AddAccountAsync(Account account);
    }
}