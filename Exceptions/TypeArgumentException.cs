using System;
using System.Runtime.Serialization;

namespace Extender.Exceptions;

/// <summary>
/// This exception is thrown when a type parameter is invalid.
/// </summary>
public class TypeArgumentException : ArgumentException
{
    public TypeArgumentException() : base() { }

    public TypeArgumentException(string message) : base(message) { }

    public TypeArgumentException(string message, Exception innerException) : base
        (message, innerException) { }

    public TypeArgumentException(string message, string paramName) : base(message, paramName) { }

    public TypeArgumentException(SerializationInfo info, StreamingContext context) : base
        (info, context) { }

    public TypeArgumentException(string message, string paramName, Exception innerException) : base
        (message, paramName, innerException) { }
}