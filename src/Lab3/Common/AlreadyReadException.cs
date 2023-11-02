using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Common;

public class AlreadyReadException : Exception
{
    public AlreadyReadException()
    {
    }

    public AlreadyReadException(string message)
        : base(message)
    {
    }

    public AlreadyReadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}