﻿using System.Runtime.Serialization;

namespace Core.CrossCuttingConcerns.Exception.Types;

public class BusinessException : System.Exception
{
    public BusinessException() { }

    protected BusinessException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

    public BusinessException(string? message)
        : base(message) { }

    public BusinessException(string? message, System.Exception? innerException)
        : base(message, innerException) { }
}
