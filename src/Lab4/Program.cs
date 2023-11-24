using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entity;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.ConnectionCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        CommandHandler connectHandler = new ConnectHandler();
        CreateChain createChain = new();
        createChain.Create(connectHandler);
        IFileSystem? fileSystem = null;
        while (true)
        {
            string? command = Console.ReadLine();
            if (string.IsNullOrEmpty(command)) return;
            var iterator = new Iterator(command);
            var request = new Request(iterator.Current());
            connectHandler.Handle(request, iterator, ref fileSystem);
        }
    }
}