using System;
using AccountManager.Application.Exceptions;

namespace AccountManager.Application.Requests.Validation
{
    /// <summary>
    /// Validates <see cref="AddUserRequest"/>
    /// </summary>
    public class AddUserRequestValidation : IRequestValidation
    {
        #region Field

        private readonly AddUserRequest request;

        #endregion

        #region Constructor

        public AddUserRequestValidation(AddUserRequest request)
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

            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentNullException(nameof(request.Name));
            }

            if (string.IsNullOrEmpty(request.Email))
            {
                throw new ArgumentNullException(nameof(request.Email));
            }

            if (request.Salary < 0)
            {
                throw new NegativeParameterException(nameof(this.request.Salary));
            }

            if (request.Expenses < 0)
            {
                throw new NegativeParameterException(nameof(this.request.Expenses));
            }
        }

        #endregion
    }
}