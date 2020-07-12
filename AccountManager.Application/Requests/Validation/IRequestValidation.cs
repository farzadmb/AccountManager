namespace AccountManager.Application.Requests.Validation
{
    /// <summary>
    /// Checks the validation of requests
    /// </summary>
    public interface IRequestValidation
    {
        /// <summary>
        /// Checks if the given object is valid
        /// </summary>
        /// <returns></returns>
        void Validate();
    }
}