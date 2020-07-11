using System;
using System.Collections.Generic;
using System.Text;

using AccountManager.Application.DTOs;
using AccountManager.Data.Models;

namespace AccountManager.Application.Extensions
{
    /// <summary>
    /// Extensions for <see cref="UserDto"/>
    /// </summary>
    public static class UserDtoExtensions
    {
        #region Public Methods

        /// <summary>
        /// Converts <see cref="UserDto"/> to <see cref="User"/>
        /// </summary>
        /// <param name="user">
        /// The user
        /// </param>
        /// <returns>
        /// The <see cref="User"/> object
        /// </returns>
        public static User ToUser(this UserDto user)
        {
            if (user == null)
            {
                return null;
            }

            return new User()
                       {
                           Id = user.Id,
                           Name = user.Name,
                           Email = user.Email,
                           Salary = user.Salary,
                           Expenses = user.Expenses
                       };
        }

        #endregion
    }
}
