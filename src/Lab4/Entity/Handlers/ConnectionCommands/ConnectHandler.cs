using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.ConnectionCommands;

public class ConnectHandler : CommandHandler, IParse, ISetMode
{
    private string _address = string.Empty;
    private string _flag = string.Empty;
    private string _mode = string.Empty;
    public void Parse(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));

        iterator.GoNext();
        _address = iterator.Current();
        iterator.GoNext();
        _flag = iterator.Current();
        iterator.GoNext();
        _mode = iterator.Current();
    }

    public IFileSystem? SetMode()
    {
        if (_mode == "local")
        {
            return new LocalFileSystem();
        }
        else
        {
            return null;
        }
    }

    public override void Handle(Request currentRequest, Iterator iterator, IFileSystem? fileSystem)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));

        if (!CanHandle(currentRequest)) base.Handle(currentRequest, iterator, fileSystem);
        Parse(iterator);
        fileSystem = SetMode();

        Console.WriteLine(_address);
        fileSystem?.Connect(_address);
    }

    protected override bool CanHandle(Request currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));

        return currentRequest.RequestText == "connect";
    }
}