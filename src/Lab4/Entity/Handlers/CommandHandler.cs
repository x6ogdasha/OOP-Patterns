using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;

public abstract class CommandHandler
{
    private CommandHandler? NextHandler { get; set; }
    public CommandHandler SetNext(CommandHandler handler)
    {
        NextHandler = handler;
        return NextHandler;
    }

    public virtual void Handle(Iterator iterator, ref SystemContext system)
    {
        NextHandler?.Handle(iterator, ref system);
    }

    protected abstract bool CanHandle(Iterator iterator);
}