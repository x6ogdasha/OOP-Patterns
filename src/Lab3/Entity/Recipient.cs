using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public abstract class Recipient : IFilter, IReceive, ISend
{
    protected Recipient()
    {
        CurrentMessage = new Message();
    }

    public Message CurrentMessage { get; protected set; }
    public int Importance { get; protected set; }

    public void Filter()
    {
        throw new System.NotImplementedException();
    }

    public void Receive(Message message)
    {
        CurrentMessage = message;
    }

    public virtual void SendTo(IReceive recipient)
    {
        throw new System.NotImplementedException();
    }

    public virtual void SendTo(IReadOnlyList<IReceive> recipients)
    {
    }
}