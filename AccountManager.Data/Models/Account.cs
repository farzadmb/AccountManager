using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountManager.Data.Models
{
    /// <summary>
    /// The Account model
    /// </summary>
    public class Account
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id of the account
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the Id of the user
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the creation date
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account is active
        /// </summary>
        public bool IsActive { get; set; }

        [ForeignKey("User")]
        public uint UserId { get; set; }

        #endregion
    }
}