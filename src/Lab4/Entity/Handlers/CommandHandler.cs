using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;

public abstract class CommandHandler
{
    private CommandHandler? NextHandler { get; set; }
    public CommandHandler SetNext(CommandHandler handler)
    {
        NextHandler = handler;
        return NextHandler;
    }

    public virtual void Handle(Request currentRequest, Iterator iterator, ref IFileSystem? fileSystem)
    {
        NextHandler?.Handle(currentRequest, iterator, ref fileSystem);
    }

    protected abstract bool CanHandle(Request currentRequest);
}