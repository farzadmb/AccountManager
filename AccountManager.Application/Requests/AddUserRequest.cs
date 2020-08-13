using System.ComponentModel.DataAnnotations;

namespace AccountManager.Application.Requests
{
    /// <summary>
    /// The request to add a user
    /// </summary>
    public class AddUserRequest
    {
        /// <summary>
        /// Gets or sets the name of the user
        /// </summary>
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email of the user
        /// </summary>
        [Required(ErrorMessage = "The email is required")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the salary of the user
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Salary is out of range")]
        public int Salary { get; set; }

        /// <summary>
        /// Gets or sets the expenses of the user
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Expenses is out of range")]
        public int Expenses { get; set; }
    }
}