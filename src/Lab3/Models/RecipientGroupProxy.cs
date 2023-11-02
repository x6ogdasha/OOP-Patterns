using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientGroupProxy : Recipient
{
    private readonly RecipientGroup _realRecipientGroup;

    public RecipientGroupProxy(RecipientGroup recipientGroup)
    {
        _realRecipientGroup = recipientGroup;
    }

    public override void SendTo(IReadOnlyList<IReceive> recipients)
    {
        if (recipients is null) throw new ArgumentNullException(nameof(recipients));
        if (Check(recipients)) _realRecipientGroup.SendTo(recipients);
    }

    private bool Check(IReadOnlyList<IReceive> recipients)
    {
        foreach (IReceive recipient in recipients)
        {
            if (!(CurrentMessage.Importance <= Importance && recipient is User)) return false;
        }

        return true;
    }
}