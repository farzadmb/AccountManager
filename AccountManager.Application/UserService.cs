using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManager.Application.DTOs;
using AccountManager.Application.Extensions;
using AccountManager.Data.DbHandlers;

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

        public async Task AddUser(UserDto user)
        {
            if (user == null)
            {
                throw new Exception();
            }

            await userDbHandler.AddUserAsync(user.ToUser());
        }

        #endregion
    }
}