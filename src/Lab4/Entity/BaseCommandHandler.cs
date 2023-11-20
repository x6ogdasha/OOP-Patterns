namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public abstract class BaseCommandHandler
{
    private BaseCommandHandler? NextHandler { get; set; }

    public void SetNext(BaseCommandHandler handler)
    {
        NextHandler = handler;
    }

    public virtual void Handle(string command)
    {
        NextHandler?.Handle(command);
    }

    protected abstract bool CanHandle(string command);
}