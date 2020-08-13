using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "UserId is required")]
        public uint UserId { get; set; }
    }
}