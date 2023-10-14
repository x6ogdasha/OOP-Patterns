using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Helpers.Exceptions;

public class ObstacleNullException : Exception
{
    public ObstacleNullException()
    {
    }

    public ObstacleNullException(string message)
        : base(message)
    {
    }

    public ObstacleNullException(string message, Exception exeption)
        : base(message, exeption)
    {
    }
}