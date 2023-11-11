using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}