using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class Display : IReceive
{
    private readonly Logger _logger = new Logger();
    private readonly DisplayDriver _displayDriver = new DisplayDriver();

    public Display(Logger logger)
    {
        _logger = logger;
    }

    public Display()
    {
    }

    public Message? CurrentMessage { get; protected set; }

    public void Receive(Message message)
    {
        CurrentMessage = message;
        _logger.Log("Сообщение получено пользователем");
    }

    public void DisplayMessage(ConsoleColor color)
    {
        if (CurrentMessage is not null)
        {
            _displayDriver.Clear();
            _displayDriver.SetColor(color);
            _displayDriver.Write(CurrentMessage.Body);
        }
    }
}