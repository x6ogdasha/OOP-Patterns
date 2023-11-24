using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.FileCommand;

public class FileCopyHandler : CommandHandler, IParse
{
    private string _sourcePath = string.Empty;
    private string _destinationPath = string.Empty;

    public void Parse(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        iterator.GoNext();
        _sourcePath = iterator.Current();
        iterator.GoNext();
        _destinationPath = iterator.Current();
    }

    public override void Handle(Request currentRequest, Iterator iterator, IFileSystem? fileSystem)
    {
        if (!CanHandle(currentRequest)) base.Handle(currentRequest, iterator, fileSystem);
        Parse(iterator);
        fileSystem?.FileCopy(_sourcePath, _destinationPath);
    }

    protected override bool CanHandle(Request currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        return currentRequest.RequestText == "copy";
    }
}