using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientUserProxy : Recipient
{
    private readonly RecipientUser _realRecipientUser;

    public RecipientUserProxy(RecipientUser realRecipientUser) => _realRecipientUser = realRecipientUser;

    public override void SendTo(IReceive recipient)
    {
        if (Check(recipient)) _realRecipientUser.SendTo(recipient);
    }

    private bool Check(IReceive recipient)
    {
        return CurrentMessage.Importance <= Importance && recipient is User;
    }
}