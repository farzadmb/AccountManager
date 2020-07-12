using System.Collections.Generic;
using System.Linq;
using AccountManager.Application.DTOs;
using AccountManager.Data.Models;

namespace AccountManager.Application.Extensions
{
    public static class AccountExtensions
    {
        #region Public Methods

        /// <summary>
        /// Converts <see cref="Account"/> to <see cref="AccountDto"/>
        /// </summary>
        /// <param name="account">
        /// The Account
        /// </param>
        /// <returns>
        /// The <see cref="AccountDto"/> object
        /// </returns>
        public static AccountDto ToAccountDto(this Account account)
        {
            if (account == null)
            {
                return null;
            }

            return new AccountDto()
                       {
                           Id = account.Id,
                           User = account.User.ToUserDto(),
                           CreationDate = account.CreationDate,
                           IsActive = account.IsActive
                       };
        }

        /// <summary>
        /// Converts a list of <see cref="Account"/> to a list of <see cref="AccountDto"/>
        /// </summary>
        /// <param name="accounts">
        /// The Accounts
        /// </param>
        /// <returns>
        /// The list of <see cref="AccountDto"/> objects
        /// </returns>
        public static IEnumerable<AccountDto> ToAccountDto(this IEnumerable<Account> accounts)
        {
            return accounts.Select(a => a.ToAccountDto()) ?? Enumerable.Empty<AccountDto>();
        }

        #endregion
    }
}