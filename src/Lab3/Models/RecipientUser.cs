using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientUser : Recipient
{
    private const int UserImportance = 0;

    public RecipientUser(Message message)
    {
        CurrentMessage = message;
        Importance = UserImportance;
    }

    public override void SendTo(IReceive recipient)
    {
        if (recipient is null) throw new ArgumentNullException(nameof(recipient));
        if (CurrentMessage.Importance <= Importance && recipient is User) recipient.Receive(CurrentMessage);
    }
}