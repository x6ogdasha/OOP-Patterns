using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.ConnectionCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.FileCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.TreeCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;

public class CreateChain : ICreateChain
{
    public void Create(CommandHandler handler)
    {
        if (handler is null) throw new ArgumentNullException(nameof(handler));
        CommandHandler treeHandler = new TreeHandler();
        CommandHandler fileHandler = new FileHandler();
        CommandHandler disconnectHandler = new DisconnectHandler();
        handler.SetNext(treeHandler).SetNext(fileHandler).SetNext(disconnectHandler);
    }
}