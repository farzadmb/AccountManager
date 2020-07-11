using AccountManager.Data.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AccountManager.Application.DTOs;
using AccountManager.Application.Extensions;

namespace AccountManager.Application
{
    /// <summary>
    /// The implementation for <see cref="IUserService"/>
    /// </summary>
    public class UserServices : IUserService
    {
        #region Fields

        private readonly IUserDbHandler userDbHandler;

        #endregion

        #region Constructor

        public UserServices(IUserDbHandler userDbHandler)
        {
            this.userDbHandler = userDbHandler;
        }

        #endregion

        #region Public Methods

        public IEnumerable<UserDto> GetAllUsers()
        {
            return userDbHandler.GetUsers().ToUserDto();
        }

        public UserDto GetUser(string email)
        {
            return userDbHandler.GetUsers().FirstOrDefault(u => u.Email == email).ToUserDto();
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
