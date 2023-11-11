using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientDisplayProxy : Recipient
{
    private readonly Recipient _realRecipientDisplay;
    private readonly Logger _logger = new Logger();

    public RecipientDisplayProxy(Recipient recipientDisplay) => _realRecipientDisplay = recipientDisplay;

    public RecipientDisplayProxy(Recipient realRecipientDisplay, Logger logger)
    {
        _realRecipientDisplay = realRecipientDisplay;
        _logger = logger;
    }

    public override void SendTo(IReceive recipient)
    {
        if (recipient is null) throw new ArgumentNullException(nameof(recipient));

        if (Check(recipient))
        {
            _realRecipientDisplay.SendTo(recipient);
        }
        else
        {
            _logger.Log("Фильтр не пройден сообщение не ушло");
        }
    }

    private bool Check(IReceive recipient)
    {
        return _realRecipientDisplay.CurrentMessage.Importance <= _realRecipientDisplay.Importance && recipient is Display;
    }
}