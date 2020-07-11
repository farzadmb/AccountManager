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
        /// The lsit of <see cref="User"/>
        /// </returns>
        IEnumerable<User> GetUsers();

        /// <summary>
        /// Returns a user
        /// </summary>
        /// <param name="userId">
        /// The Id of the user
        /// </param>
        /// <returns>
        /// The <see cref="User"/>
        /// </returns>
        User GetUser(int userId);

        /// <summary>
        /// Returns a user
        /// </summary>
        /// <param name="email">
        /// The email of the user
        /// </param>
        /// <returns>
        /// The <see cref="User"/>
        /// </returns>
        User GetUser(string email);

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