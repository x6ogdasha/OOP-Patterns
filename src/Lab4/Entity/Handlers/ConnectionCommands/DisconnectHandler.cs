using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.ConnectionCommands;

public class DisconnectHandler : CommandHandler
{
    public override void Handle(Request currentRequest, Iterator iterator, IFileSystem? fileSystem)
    {
        if (CanHandle(currentRequest))
        {
            fileSystem?.Disconnect();
        }
        else
        {
            base.Handle(currentRequest, iterator, fileSystem);
        }
    }

    protected override bool CanHandle(Request currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        return currentRequest.RequestText == "disconnect";
    }
}