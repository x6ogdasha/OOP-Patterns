using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Helpers.Exceptions;

public class ObstacleWrongTypeException : Exception
{
    public ObstacleWrongTypeException()
    {
    }

    public ObstacleWrongTypeException(string message)
        : base(message)
    {
    }

    public ObstacleWrongTypeException(string message, Exception exeption)
        : base(message, exeption)
    {
    }
}