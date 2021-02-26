using System;
using System.Runtime.Serialization;

namespace BlamanticUI
{
    /// <summary>
    /// The exception that is thrown when the string type of argument is null or empty.
    /// </summary>
    /// <seealso cref="System.ArgumentException" />
    public class StringNullOrEmptyException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringNullOrEmptyException"/> class.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        public StringNullOrEmptyException(string? paramName) : this("Cannot be null or empty string", paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringNullOrEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
        public StringNullOrEmptyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringNullOrEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        public StringNullOrEmptyException(string? message, string? paramName) : base(message, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringNullOrEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
        public StringNullOrEmptyException(string? message, string? paramName, Exception? innerException) : base(message, paramName, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringNullOrEmptyException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected StringNullOrEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
