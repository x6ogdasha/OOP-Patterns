using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientUser : Recipient
{
    private const int UserImportance = 0;
    private readonly Logger _logger = new Logger();

    public RecipientUser(Message message)
    {
        CurrentMessage = message;
        Importance = UserImportance;
        _logger.Log("Сообщение получено адресатом-пользователем");
    }

    public override void SendTo(IReceive recipient)
    {
        if (recipient is null) throw new ArgumentNullException(nameof(recipient));
        recipient.Receive(CurrentMessage);
    }
}