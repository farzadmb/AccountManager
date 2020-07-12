using System;

namespace AccountManager.Application.Exceptions
{
    /// <summary>
    /// User is not eligible to create an account
    /// </summary>
    public class UserIsNotEligibleToCreateAccountException : Exception
    {
        #region Constructor

        public UserIsNotEligibleToCreateAccountException()
            : base("User is not eligible to create an account")
        {
        }

        #endregion
    }
}