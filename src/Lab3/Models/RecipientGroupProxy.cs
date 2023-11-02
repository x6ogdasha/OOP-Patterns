using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientGroupProxy : Recipient
{
    private readonly Recipient _realRecipientGroup;
    private readonly Logger _logger = new Logger();

    public RecipientGroupProxy(Recipient recipientGroup) => _realRecipientGroup = recipientGroup;

    public RecipientGroupProxy(Recipient realRecipientGroup, Logger logger)
    {
        _realRecipientGroup = realRecipientGroup;
        _logger = logger;
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
            if (!(CurrentMessage.Importance <= Importance && recipient is User))
            {
                return false;
            }
        }

        _logger.Log("Фильтр пройден сообщения уходят");
        return true;
    }
}