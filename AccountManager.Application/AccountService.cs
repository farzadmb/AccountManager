using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManager.Application.DTOs;
using AccountManager.Application.Exceptions;
using AccountManager.Application.Extensions;
using AccountManager.Application.Requests;
using AccountManager.Application.Requests.Validation;
using AccountManager.Data.DbHandlers;
using AccountManager.Data.Models;

namespace AccountManager.Application
{
    /// <summary>
    /// Implementation for <see cref="IAccountService"/>
    /// </summary>
    public class AccountService : IAccountService
    {
        #region Fields

        private readonly IAccountDbHandler accountDbHandler;

        private readonly IUserDbHandler userDbHandler;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="accountDbHandler">
        /// The account database handler
        /// </param>
        /// <param name="userDbHandler">
        /// The user database handler
        /// </param>
        public AccountService(IAccountDbHandler accountDbHandler, IUserDbHandler userDbHandler)
        {
            this.accountDbHandler = accountDbHandler;
            this.userDbHandler = userDbHandler;
        }

        #endregion

        #region Public Methods

        public async Task<IEnumerable<AccountDto>> GetAllAccounts()
        {
            var accounts = await accountDbHandler.GetAccountsAsync();
            return accounts.ToAccountDto();
        }

        public async Task<IEnumerable<AccountDto>> GetUserAccounts(int userId)
        {
            var accounts = await accountDbHandler.GetUserAccountsAsync(userId);
            return accounts.ToAccountDto();
        }

        public async Task AddAccountAsync(AddAccountRequest request)
        {
            var validator = new AddAccountRequestValidation(request);
            validator.Validate();

            var users = await userDbHandler.GetUsersAsync();
            var user = users.FirstOrDefault(u => u.Id == request.UserId);

            if (user == null)
            {
                throw new UserNotFountException(request.UserId);
            }

            if (user.Salary - user.Expenses < 1000)
            {
                throw new UserIsNotEligibleToCreateAccountException();
            }

            var account = new Account() { UserId = request.UserId, CreationDate = DateTime.UtcNow, IsActive = true };
            await accountDbHandler.AddAccountAsync(account);
        }

        #endregion
    }
}