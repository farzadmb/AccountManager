using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManager.Application.DTOs;
using AccountManager.Application.Requests;

namespace AccountManager.Application
{
    /// <summary>
    /// The services for User
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Returns the list of all users
        /// </summary>
        /// <returns>
        /// The list of <see cref="UserDto"/>
        /// </returns>
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        /// <summary>
        /// Returns a user
        /// </summary>
        /// <param name="email">
        /// The email of the user
        /// </param>
        /// <returns>
        /// The <see cref="UserDto"/>
        /// </returns>
        Task<UserDto> GetUserAsync(string email);

        /// <summary>
        /// Adds the given user to the database
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// </returns>
        Task AddUser(AddUserRequest request);
    }
}