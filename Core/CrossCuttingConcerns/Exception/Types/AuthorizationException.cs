using System.Runtime.Serialization;

namespace Core.CrossCuttingConcerns.Exception.Types;

public class AuthorizationException : System.Exception
{
    public AuthorizationException() { }

    protected AuthorizationException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

    public AuthorizationException(string? message)
        : base(message) { }

    public AuthorizationException(string? message, System.Exception? innerException)
        : base(message, innerException) { }
}
