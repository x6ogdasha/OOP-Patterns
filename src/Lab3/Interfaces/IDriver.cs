using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface IDriver
{
    public void Clear();
    public void Write(string text);
    public void SetColor(ConsoleColor color);
}