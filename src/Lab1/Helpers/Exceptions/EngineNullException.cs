using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Helpers.Exceptions;

public class EngineNullException : Exception
{
    public EngineNullException()
    {
    }

    public EngineNullException(string message)
        : base(message)
    {
    }

    public EngineNullException(string message, Exception exeption)
        : base(message, exeption)
    {
    }
}