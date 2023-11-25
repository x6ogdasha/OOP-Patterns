using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public class Request
{
    public Request(string command)
    {
        RequestText = command;
    }

    public string RequestText { get; set; }
    public CommandHandler? CurrentHandler { get; set; }
    public string? Flag { get; set; }
    public string? Mode { get; set; }
    public string? FirstPath { get; set; }
    public string? SecondPath { get; set; }
    public int? Depth { get; set; }
}