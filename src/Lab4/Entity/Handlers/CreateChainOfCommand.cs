using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.ConnectionCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.FileCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.TreeCommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;

public class CreateChainOfCommand
{
    public CreateChainOfCommand(CommandHandler handler)
    {
        Handler = handler;
    }

    public CommandHandler Handler { get; set; }
    public void Create()
    {
        CommandHandler treeHandler = new TreeHandler();
        CommandHandler fileHandler = new FileHandler();
        CommandHandler disconnectHandler = new DisconnectHandler();
        Handler.SetNext(treeHandler).SetNext(fileHandler).SetNext(disconnectHandler);
    }
}