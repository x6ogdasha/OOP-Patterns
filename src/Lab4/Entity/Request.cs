using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public class Request
{
    public Request(string command)
    {
        RequestText = command;
    }

    public Request()
    {
        RequestText = string.Empty;
    }

    public string RequestText { get; set; }
    public CommandHandler? CurrentHandler { get; set; }
    public Dictionary<string, string> Flags { get; } = new Dictionary<string, string>();
    public string? FirstPath { get; set; } = string.Empty;
    public string SecondPath { get; set; } = string.Empty;
}