using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using AccountManager.Application.DTOs;

namespace AccountManager.Application
{
    public interface IUserService
    {
        /// <summary>
        /// Returns the list of all users
        /// </summary>
        /// <returns>
        /// The list of <see cref="UserDto"/>
        /// </returns>
        IEnumerable<UserDto> GetAllUsers();

        /// <summary>
        /// Returns a user
        /// </summary>
        /// <param name="email">
        /// The email of the user
        /// </param>
        /// <returns>
        /// The <see cref="UserDto"/>
        /// </returns>
        UserDto GetUser(string email);

        /// <summary>
        /// Adds the given user to the database
        /// </summary>
        /// <param name="user">
        /// The new user
        /// </param>
        /// <returns>
        /// </returns>
        Task AddUser(UserDto user);
    }
}