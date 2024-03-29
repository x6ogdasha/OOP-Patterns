using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class Messenger : IReceive
{
    private readonly Logger _logger = new Logger();
    public Messenger(Logger logger)
    {
        _logger = logger;
    }

    public Messenger()
    {
    }

    public Message? CurrentMessage { get; protected set; }

    public void Receive(Message message)
    {
        CurrentMessage = message;
        _logger.Log("Сообщение получено мессенджером");
    }

    public void DisplayMessage()
    {
        if (CurrentMessage is not null) Console.WriteLine(CurrentMessage.Body + " From Messanger");
    }
}