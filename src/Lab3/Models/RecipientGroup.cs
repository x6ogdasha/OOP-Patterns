using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientGroup : Recipient
{
    private const int GroupImportance = 0;

    public RecipientGroup(Message message)
    {
        CurrentMessage = message;
        Importance = GroupImportance;
    }

    public override void SendTo(IReadOnlyList<IReceive> recipients)
    {
        if (recipients is null) throw new ArgumentNullException(nameof(recipients));
        foreach (IReceive recipient in recipients)
        {
            if (CurrentMessage.Importance <= Importance && recipient is User) recipient.Receive(CurrentMessage);
        }
    }
}