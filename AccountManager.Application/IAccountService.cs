using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManager.Application.DTOs;
using AccountManager.Application.Requests;

namespace AccountManager.Application
{
    public interface IAccountService
    {
        /// <summary>
        /// Returns all the accounts
        /// </summary>
        /// <returns>
        /// The list of <see cref="AccountDto"/>
        /// </returns>
        Task<IEnumerable<AccountDto>> GetAllAccounts();

        /// <summary>
        /// Returns the accounts of a user
        /// </summary>
        /// <param name="userId">
        /// The Id of the user
        /// </param>
        /// <returns>
        /// The list of <see cref="AccountDto"/>
        /// </returns>
        Task<IEnumerable<AccountDto>> GetUserAccounts(int userId);

        /// <summary>
        /// Adds an account for a user
        /// </summary>
        /// <param name="request">
        /// The request
        /// </param>
        /// <returns>
        /// </returns>
        Task AddAccountAsync(AddAccountRequest request);
    }
}