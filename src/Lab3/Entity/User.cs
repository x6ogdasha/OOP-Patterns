using Itmo.ObjectOrientedProgramming.Lab3.Common;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class User : IReceive, IRead
{
    private readonly Logger _logger = new Logger();
    public Message CurrentMessage { get; protected set; } = new();
    public Status MessageStatus { get; protected set; }
    public void Receive(Message message)
    {
        CurrentMessage = message;
        MessageStatus = Status.Unread;
        _logger.Log("Сообщение получено пользователем");
    }

    public void Read()
    {
        if (MessageStatus == Status.Unread) MessageStatus = Status.Read;
    }
}