using System;

namespace AccountManager.Application.Requests.Validation
{
    /// <summary>
    /// Validates <see cref="AddAccountRequest"/>
    /// </summary>
    public class AddAccountRequestValidation : IRequestValidation
    {
        #region Field

        private readonly AddAccountRequest request;

        #endregion

        #region Constructor

        public AddAccountRequestValidation(AddAccountRequest request)
        {
            this.request = request;
        }

        #endregion

        #region Validation

        public void Validate()
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
        }

        #endregion
    }
}