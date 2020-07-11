using AccountManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Data.DbHandlers
{
    /// <summary>
    /// The database services for <see cref="User"/>
    /// </summary>
    public interface IUserDbHandler
    {
        /// <summary>
        /// Returns the list of all users
        /// </summary>
        /// <returns>
        /// The list of <see cref="User"/>
        /// </returns>
        IEnumerable<User> GetUsers();

        /// <summary>
        /// Adds the given user to the database
        /// </summary>
        /// <param name="user">
        /// The new user
        /// </param>
        /// <returns>
        /// </returns>
        Task AddUserAsync(User user);
    }
}