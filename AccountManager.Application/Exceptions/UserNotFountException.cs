using System;

namespace AccountManager.Application.Exceptions
{
    /// <summary>
    /// Exception with invalid userId
    /// </summary>
    public class UserNotFountException : Exception
    {
        #region Constructor

        public UserNotFountException(uint userId)
            : base($"User with Id {userId} is not found")
        {
        }

        #endregion
    }
}