namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public class ConnectCommandHandler : BaseCommandHandler
{
    public override void Handle(string command)
    {
        if (CanHandle(command))
        {
        }
        else
        {
        }
    }

    protected override bool CanHandle(string command)
    {
        return command == "connect";
    }
}