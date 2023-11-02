using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public abstract class Recipient : IReceive, ISend
{
    protected Recipient()
    {
        CurrentMessage = new Message();
    }

    public Message CurrentMessage { get; protected set; }
    public int Importance { get; protected set; }

    public void Receive(Message message)
    {
        CurrentMessage = message;
    }

    public virtual void SendTo(IReceive recipient)
    {
    }

    public virtual void SendTo(IReadOnlyList<IReceive> recipients)
    {
    }
}