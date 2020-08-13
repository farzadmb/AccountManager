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
    /// The implementation for <see cref="IUserService"/>
    /// </summary>
    public class UserService : IUserService
    {
        #region Fields

        private readonly IUserDbHandler userDbHandler;

        #endregion

        #region Constructor

        public UserService(IUserDbHandler userDbHandler)
        {
            this.userDbHandler = userDbHandler;
        }

        #endregion

        #region Public Methods

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await userDbHandler.GetUsersAsync();
            return users.ToUserDto();
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            var users = await userDbHandler.GetUsersAsync();
            return users.FirstOrDefault(u => u.Email == email).ToUserDto();
        }

        public async Task AddUserAsync(AddUserRequest request)
        {
            var existingUsers = await userDbHandler.GetUsersAsync();
            var existingUser = existingUsers.FirstOrDefault(
                u => string.Equals(request.Email, u.Email, StringComparison.InvariantCultureIgnoreCase));

            if (existingUser != null)
            {
                throw new DuplicateEmailException(request.Email);
            }

            var user = new User()
                           {
                               Name = request.Name,
                               Email = request.Email,
                               Salary = (uint) request.Salary,
                               Expenses = (uint) request.Expenses
                           };

            await userDbHandler.AddUserAsync(user);
        }

        #endregion
    }
}