using AccountManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Data.DbHandlers
{
    public interface IAccountDbHandler
    {
        IEnumerable<Account> GetAccounts();

        Account GetAccount(int id);

        IEnumerable<Account> GetUserAccounts(int userId);

        Task AddAccount(Account account);
    }
}
