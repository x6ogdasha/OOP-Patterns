using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;

public abstract class FlagHandler
{
    private FlagHandler? NextHandler { get; set; }
    public FlagHandler SetNext(FlagHandler handler)
    {
        NextHandler = handler;
        return NextHandler;
    }

    public virtual void Handle(Iterator iterator, Dictionary<string, string> flags, ref SystemContext system)
    {
        NextHandler?.Handle(iterator, flags, ref system);
    }

    protected abstract bool CanHandle(Iterator iterator);
}