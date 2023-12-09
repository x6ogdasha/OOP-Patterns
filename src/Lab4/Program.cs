using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entity;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.ConnectionCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        CommandHandler connectHandler = new ConnectHandler();
        CreateChainOfCommand createChainOfCommand = new(connectHandler);
        createChainOfCommand.Create();
        var system = new SystemContext();
        while (true)
        {
            string? command = Console.ReadLine();
            if (string.IsNullOrEmpty(command)) return;
            var iterator = new Iterator(command);
            connectHandler.Handle(iterator, ref system);
        }
    }
}