using Itmo.ObjectOrientedProgramming.Lab4.Common;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public abstract class CommandHandler
{
    private CommandHandler? NextHandler { get; set; }

    public void SetNext(CommandHandler handler)
    {
        NextHandler = handler;
    }

    public virtual void Handle(string currentRequest, Iterator iterator, Properties properties)
    {
        NextHandler?.Handle(currentRequest, iterator, properties);
    }

    protected abstract bool CanHandle(string currentRequest);
}