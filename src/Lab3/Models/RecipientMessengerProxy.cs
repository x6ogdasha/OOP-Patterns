using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class RecipientMessengerProxy : Recipient
{
   private readonly RecipientMessenger _realRecipientMessenger;

   public RecipientMessengerProxy(RecipientMessenger realRecipientMessenger) => _realRecipientMessenger = realRecipientMessenger;

   public override void SendTo(IReceive recipient)
   {
      if (recipient is null) throw new ArgumentNullException(nameof(recipient));

      if (Check(recipient)) _realRecipientMessenger.SendTo(recipient);
   }

   private bool Check(IReceive recipient)
   {
      return CurrentMessage.Importance <= Importance && recipient is Messenger;
   }
}