using System;

namespace AccountManager.Application.DTOs
{
    public class AccountDto
    {
        /// <summary>
        /// Gets or sets the Id of the account
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the Id of the user
        /// </summary>
        public UserDto User { get; set; }

        /// <summary>
        /// Gets or sets the creation date
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account is active
        /// </summary>
        public bool IsActive { get; set; }
    }
}