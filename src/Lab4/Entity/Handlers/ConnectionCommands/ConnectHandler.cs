using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.ConnectionCommands;

public class ConnectHandler : CommandHandler, IParse, ISetMode
{
    private string _address = string.Empty;
    private string _flag = string.Empty;
    private string _mode = string.Empty;
    public Request? CurrentRequest { get; private set; }
    public void Parse(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));

        iterator.GoNext();
        _address = iterator.Current();
        iterator.GoNext();
        _flag = iterator.Current();
        iterator.GoNext();
        _mode = iterator.Current();
        if (CurrentRequest is not null)
        {
            CurrentRequest.Flag = _flag;
            CurrentRequest.Mode = _mode;
            CurrentRequest.FirstPath = _address;
        }
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

    public override void Handle(Request currentRequest, Iterator iterator, ref IFileSystem? fileSystem)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));

        if (!CanHandle(currentRequest))
        {
            base.Handle(currentRequest, iterator, ref fileSystem);
        }
        else
        {
            CurrentRequest = currentRequest;
            CurrentRequest.CurrentHandler = new ConnectHandler();
            Parse(iterator);
            fileSystem = SetMode();
            fileSystem?.Connect(_address);
        }
    }

    protected override bool CanHandle(Request currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));

        return currentRequest.RequestText == "connect";
    }
}