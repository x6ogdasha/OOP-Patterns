using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Helpers.Exceptions;

public class ShipNullException : Exception
{
    public ShipNullException()
    {
    }

    public ShipNullException(string message)
        : base(message)
    {
    }

    public ShipNullException(string message, Exception exeption)
        : base(message, exeption)
    {
    }
}