using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManager.Application.Requests
{
    /// <summary>
    /// The request to create an account
    /// </summary>
    public class AddAccountRequest
    {
        /// <summary>
        /// Gets or sets the Id of the owner
        /// </summary>
        public uint UserId { get; set; }
    }
}