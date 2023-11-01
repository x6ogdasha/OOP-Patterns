using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class Messenger : IReceive, IDisplay
{
    public Message? CurrentMessage { get; protected set; }

    public void Receive(Message message)
    {
        CurrentMessage = message;
    }

    public void DisplayMessage()
    {
        if (CurrentMessage is not null) Console.WriteLine(CurrentMessage.Body + " From Messanger");
    }
}