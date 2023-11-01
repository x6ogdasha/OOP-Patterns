using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientDisplay : Recipient
{
    private const int DisplayImportance = 3;

    public RecipientDisplay(Message message)
    {
        CurrentMessage = message;
        Importance = DisplayImportance;
    }

    public override void SendTo(IReceive recipient)
    {
        if (recipient is null) throw new ArgumentNullException(nameof(recipient));
        if (CurrentMessage.Importance <= Importance && recipient is Display) recipient.Receive(CurrentMessage);
    }
}