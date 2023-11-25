using Itmo.ObjectOrientedProgramming.Lab4.Entity;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.ConnectionCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.FileCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.TreeCommand;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Test4
{
    [Fact]
    public void TestConnecting()
    {
        CommandHandler connectHandler = new ConnectHandler();
        CreateChain createChain = new();
        createChain.Create(connectHandler);
        IFileSystem? fileSystem = null;

        string command = "connect /Users/6ogdasha/Desktop/Богдан/ИТМО -m local";
        var iterator = new Iterator(command);
        var request = new Request(iterator.Current());
        connectHandler.Handle(request, iterator, ref fileSystem);

        Assert.Equal("/Users/6ogdasha/Desktop/Богдан/ИТМО", request.FirstPath);
        Assert.Equal("-m", request.Flag);
        Assert.Equal("local", request.Mode);
        Assert.True(request.CurrentHandler is ConnectHandler);
    }

    [Fact]
    public void TestFileMove()
    {
        CommandHandler connectHandler = new ConnectHandler();
        CreateChain createChain = new();
        createChain.Create(connectHandler);
        IFileSystem? fileSystem = null;

        string command = "file move /Users/6ogdasha/Desktop/Богдан/ИТМО /Users/6ogdasha/Desktop/Богдан/ИТМО/БД";
        var iterator = new Iterator(command);
        var request = new Request(iterator.Current());
        connectHandler.Handle(request, iterator, ref fileSystem);

        Assert.Equal("/Users/6ogdasha/Desktop/Богдан/ИТМО", request.FirstPath);
        Assert.Equal("/Users/6ogdasha/Desktop/Богдан/ИТМО/БД", request.SecondPath);
        Assert.True(request.CurrentHandler is FileMoveHandler);
    }

    [Fact]
    public void TestTreeList()
    {
        CommandHandler connectHandler = new ConnectHandler();
        CreateChain createChain = new();
        createChain.Create(connectHandler);
        IFileSystem? fileSystem = null;

        string command = "tree list -d 5";
        var iterator = new Iterator(command);
        var request = new Request(iterator.Current());
        connectHandler.Handle(request, iterator, ref fileSystem);

        Assert.Equal("-d", request.Flag);
        Assert.Equal(5, request.Depth);
        Assert.True(request.CurrentHandler is TreeListHandler);
    }
}