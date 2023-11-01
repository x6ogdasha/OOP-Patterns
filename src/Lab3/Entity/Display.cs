using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class Display : IReceive, IDisplay
{
    public Message? CurrentMessage { get; protected set; }
    public string Color { get; protected set; } = string.Empty;
    public void Receive(Message message)
    {
        throw new System.NotImplementedException();
    }

    public void DisplayMessage()
    {
        if (CurrentMessage is not null) Console.WriteLine(CurrentMessage.Body + " " + Color);
    }
}