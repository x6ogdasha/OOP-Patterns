using Itmo.ObjectOrientedProgramming.Lab4.Entity;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.ConnectionCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.FileCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.TreeCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Service;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Test4
{
    [Fact]
    public void TestConnecting()
    {
        var connectHandler = new ConnectHandler();
        CreateChainOfCommand createChainOfCommand = new(connectHandler);
        createChainOfCommand.Create();
        var system = new SystemContext();

        string command = "connect /Users/6ogdasha/Desktop/Богдан/ИТМО -m local";
        var iterator = new Iterator(command);
        connectHandler.Handle(iterator, ref system);

        Assert.Equal("/Users/6ogdasha/Desktop/Богдан/ИТМО", connectHandler.Address);
        Assert.True(system?.LastHandler is ConnectHandler);
    }

    [Fact]
    public void TestFileMove()
    {
        CommandHandler connectHandler = new ConnectHandler();
        CreateChainOfCommand createChainOfCommand = new(connectHandler);
        createChainOfCommand.Create();
        var system = new SystemContext();
        system.FileSystem = new LocalFileSystem();

        string command = "file move /Users/6ogdasha/Desktop/Богдан/ИТМО /Users/6ogdasha/Desktop/Богдан/ИТМО/БД";
        var iterator = new Iterator(command);
        connectHandler.Handle(iterator, ref system);
        Assert.True(system?.LastHandler is FileMoveHandler);
    }

    [Fact]
    public void TestTreeList()
    {
        CommandHandler connectHandler = new ConnectHandler();
        CreateChainOfCommand createChainOfCommand = new(connectHandler);
        createChainOfCommand.Create();
        var system = new SystemContext();

        string command = "tree list -d 5";
        var iterator = new Iterator(command);
        connectHandler.Handle(iterator, ref system);
        Assert.True(system?.LastHandler is TreeListHandler);
    }
}