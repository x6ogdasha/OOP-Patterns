using Itmo.ObjectOrientedProgramming.Lab3.Common;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class User : IReceive, IRead
{
    public Message CurrentMessage { get; protected set; } = new();
    public Status MessageStatus { get; protected set; }

    // public void SendTo(Recipient recipient, Message message)
    // {
    //     if (recipient is null) throw new ArgumentNullException(nameof(recipient));
    //     recipient.Receive(message);
    // } ЗДЕСЬ НУЖЕН АДАПТЕР ДЛЯ ISEND
    public void Receive(Message message)
    {
        CurrentMessage = message;
        MessageStatus = Status.Unread;
    }

    public void Read()
    {
        if (MessageStatus == Status.Unread) MessageStatus = Status.Read;
    }
}