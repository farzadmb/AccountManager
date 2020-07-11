namespace AccountManager.Application.DTOs
{
    public class UserDto
    {
        /// <summary>
        /// Gets or sets the Id od the user
        /// </summary>
        public uint Id { get; set; }

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
        public uint Salary { get; set; }

        /// <summary>
        /// Gets or sets the expenses of the user
        /// </summary>
        public uint Expenses { get; set; }
    }
}