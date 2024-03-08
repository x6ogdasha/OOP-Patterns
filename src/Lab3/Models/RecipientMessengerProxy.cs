using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientMessengerProxy : Recipient
{
   private readonly Recipient _realRecipientMessenger;
   private readonly Logger _logger = new Logger();

   public RecipientMessengerProxy(Recipient realRecipientMessenger) => _realRecipientMessenger = realRecipientMessenger;

   public RecipientMessengerProxy(Recipient realRecipientMessenger, Logger logger)
   {
      _realRecipientMessenger = realRecipientMessenger;
      _logger = logger;
   }

   public override void SendTo(IReceive recipient)
   {
      if (recipient is null) throw new ArgumentNullException(nameof(recipient));

      if (Check(recipient))
      {
         _realRecipientMessenger.SendTo(recipient);
      }
      else
      {
         _logger.Log("Фильтр не пройден сообщение не уходит");
      }
   }

   private bool Check(IReceive recipient)
   {
      return _realRecipientMessenger.CurrentMessage.Importance <= _realRecipientMessenger.Importance && recipient is Messenger;
   }
}