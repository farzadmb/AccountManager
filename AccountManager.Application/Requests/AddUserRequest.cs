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
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the salary of the user
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// Gets or sets the expenses of the user
        /// </summary>
        public int Expenses { get; set; }
    }
}