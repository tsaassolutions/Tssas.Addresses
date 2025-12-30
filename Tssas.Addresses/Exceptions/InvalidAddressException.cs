namespace Tssas.Addresses.Exceptions
{
    /// <summary>
    /// Exception thrown when an address is invalid or contains invalid data.
    /// </summary>
    public class InvalidAddressException : Exception
    {
        /// <summary>
        /// Gets the name of the property that caused the exception, if applicable.
        /// </summary>
        public string? PropertyName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidAddressException"/> class.
        /// </summary>
        public InvalidAddressException()
            : base("The address is invalid.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidAddressException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidAddressException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidAddressException"/> class with a specified error message and property name.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="propertyName">The name of the property that caused the exception.</param>
        public InvalidAddressException(string message, string propertyName)
            : base(message)
        {
            PropertyName = propertyName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidAddressException"/> class with a specified error message and a reference to the inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidAddressException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidAddressException"/> class with a specified error message, property name, and a reference to the inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="propertyName">The name of the property that caused the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidAddressException(string message, string propertyName, Exception innerException)
            : base(message, innerException)
        {
            PropertyName = propertyName;
        }
    }
}
