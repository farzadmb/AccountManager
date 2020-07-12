using System;

namespace AccountManager.Application.Exceptions
{
    /// <summary>
    /// Exception for duplicate email
    /// </summary>
    public class DuplicateEmailException : Exception
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateEmailException"/> class.
        /// </summary>
        /// <param name="email">
        /// The email
        /// </param>
        public DuplicateEmailException(string email): base($"Email {email} belongs to another user")
        {
        }

        #endregion
    }
}