namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public class Request
{
    public Request(string command)
    {
        RequestText = command;
    }

    public string RequestText { get; set; }
}