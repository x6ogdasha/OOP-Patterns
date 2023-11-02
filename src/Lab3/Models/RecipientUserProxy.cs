using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientUserProxy : Recipient
{
    private readonly Recipient _realRecipientUser;
    private readonly Logger _logger = new Logger();

    public RecipientUserProxy(Recipient realRecipientUser) => _realRecipientUser = realRecipientUser;

    public RecipientUserProxy(Recipient realRecipientUser, Logger logger)
    {
        _realRecipientUser = realRecipientUser;
        _logger = logger;
    }

    public override void SendTo(IReceive recipient)
    {
        if (Check(recipient))
        {
            _realRecipientUser.SendTo(recipient);
        }
        else
        {
            _logger.Log("Фильтр не пройден сообщение не уходит");
        }
    }

    private bool Check(IReceive recipient)
    {
        return CurrentMessage.Importance <= Importance && recipient is User;
    }
}