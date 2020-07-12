using System;

namespace AccountManager.Application.Exceptions
{
    /// <summary>
    /// Exception for negative parameters
    /// </summary>
    public class NegativeParameterException : Exception
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NegativeParameterException"/> class.
        /// </summary>
        /// <param name="parameter">
        /// The name of parameter
        /// </param>
        public NegativeParameterException(string parameter)
            : base($"Negative value is not acceptable for parameter {parameter}")
        {
        }

        #endregion
    }
}