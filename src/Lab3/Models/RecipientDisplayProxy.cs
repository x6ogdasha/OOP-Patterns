using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientDisplayProxy : Recipient
{
    private readonly RecipientDisplay _realRecipientDisplay;

    public RecipientDisplayProxy(RecipientDisplay recipientDisplay) => _realRecipientDisplay = recipientDisplay;

    public override void SendTo(IReceive recipient)
    {
        if (recipient is null) throw new ArgumentNullException(nameof(recipient));

        if (Check(recipient)) _realRecipientDisplay.SendTo(recipient);
    }

    private bool Check(IReceive recipient)
    {
        return _realRecipientDisplay.CurrentMessage.Importance <= _realRecipientDisplay.Importance && recipient is Display;
    }
}