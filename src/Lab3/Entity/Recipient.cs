using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public abstract class Recipient : IReceive, ISend
{
    public Message CurrentMessage { get; protected set; } = new();
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