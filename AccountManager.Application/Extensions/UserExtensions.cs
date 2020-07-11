using System.Collections.Generic;
using System.Linq;
using AccountManager.Application.DTOs;
using AccountManager.Data.Models;

namespace AccountManager.Application.Extensions
{
    /// <summary>
    /// Extensions for <see cref="User"/>
    /// </summary>
    public static class UserExtensions
    {
        #region Public Methods

        /// <summary>
        /// Converts <see cref="User"/> to <see cref="UserDto"/>
        /// </summary>
        /// <param name="user">
        /// The user
        /// </param>
        /// <returns>
        /// The <see cref="UserDto"/> object
        /// </returns>
        public static UserDto ToUserDto(this User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserDto()
                       {
                           Id = user.Id,
                           Name = user.Name,
                           Email = user.Email,
                           Salary = user.Salary,
                           Expenses = user.Expenses
                       };
        }

        /// <summary>
        /// Converts a list of <see cref="User"/> to a list of <see cref="UserDto"/>
        /// </summary>
        /// <param name="users">
        /// The users
        /// </param>
        /// <returns>
        /// The list of <see cref="UserDto"/> object
        /// </returns>
        public static IEnumerable<UserDto> ToUserDto(this IEnumerable<User> users)
        {
            return users?.Select(u => u.ToUserDto());
        }

        #endregion
    }
}