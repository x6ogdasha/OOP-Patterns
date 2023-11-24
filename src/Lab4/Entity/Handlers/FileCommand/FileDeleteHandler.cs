using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.FileCommand;

public class FileDeleteHandler : CommandHandler, IParse
{
    private string _path = string.Empty;

    public void Parse(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        iterator.GoNext();
        _path = iterator.Current();
    }

    public override void Handle(Request currentRequest, Iterator iterator, IFileSystem? fileSystem)
    {
        if (!CanHandle(currentRequest)) base.Handle(currentRequest, iterator, fileSystem);
        Parse(iterator);
        fileSystem?.FileDelete(_path);
    }

    protected override bool CanHandle(Request currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        return currentRequest.RequestText == "delete";
    }
}