using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;

public class CreateChainOfFlags
{
    public CreateChainOfFlags(FlagHandler handler)
    {
        Handler = handler;
    }

    public FlagHandler Handler { get; set; }
    public void Create()
    {
        FlagHandler depthHandler = new DepthHandler();
        Handler.SetNext(depthHandler);
    }
}