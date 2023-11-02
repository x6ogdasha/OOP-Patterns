using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientDisplay : Recipient
{
    private const int DisplayImportance = 3;
    private readonly Logger _logger = new Logger();
    public RecipientDisplay(Message message)
    {
        CurrentMessage = message;
        Importance = DisplayImportance;
        _logger.Log("Сообщение получено адресатом-дисплеем");
    }

    public override void SendTo(IReceive recipient)
    {
        if (recipient is null) throw new ArgumentNullException(nameof(recipient));
        recipient.Receive(CurrentMessage);
    }
}