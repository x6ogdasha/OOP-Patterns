namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public class Request
{
    public Request(string command)
    {
        CommandText = command;
    }

    public string CommandText { get; set; }
}