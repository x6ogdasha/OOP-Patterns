using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientGroup : Recipient
{
    private const int GroupImportance = 0;
    private readonly Logger _logger = new Logger();
    public RecipientGroup(Message message)
    {
        CurrentMessage = message;
        Importance = GroupImportance;
        _logger.Log("Сообщение получено адресатом-группой");
    }

    public override void SendTo(IReadOnlyList<IReceive> recipients)
    {
        if (recipients is null) throw new ArgumentNullException(nameof(recipients));
        foreach (IReceive recipient in recipients)
        {
            recipient.Receive(CurrentMessage);
        }
    }
}