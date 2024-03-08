using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class DisplayDriver : IDriver
{
    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}