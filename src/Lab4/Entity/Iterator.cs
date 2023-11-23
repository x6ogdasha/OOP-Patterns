using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public class Iterator : IIterator
{
    private string[] _command;
    private int _position;

    public Iterator(string command)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));
        _command = command.Split(' ');
        _position = 0;
    }

    public void GoNext()
    {
        _position++;
    }

    public void Reset()
    {
        _position = 0;
    }

    public string Current()
    {
        return _command[_position];
    }
}