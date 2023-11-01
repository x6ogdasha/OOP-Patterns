using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientMessenger : Recipient
{
    private const int MessengerImportance = 1;

    public RecipientMessenger(Message message)
    {
        CurrentMessage = message;
        Importance = MessengerImportance;
    }

    public override void SendTo(IReceive recipient)
    {
        if (recipient is null) throw new ArgumentNullException(nameof(recipient));
        if (CurrentMessage.Importance <= Importance && recipient is Messenger) recipient.Receive(CurrentMessage);
    }
}