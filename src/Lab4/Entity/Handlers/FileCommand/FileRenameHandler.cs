using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.FileCommand;

public class FileRenameHandler : CommandHandler, IParse
{
    private string _path = string.Empty;
    private string _newName = string.Empty;

    public void Parse(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        iterator.GoNext();
        _path = iterator.Current();
        iterator.GoNext();
        _newName = iterator.Current();
    }

    public override void Handle(Request currentRequest, Iterator iterator, ref IFileSystem? fileSystem)
    {
        if (!CanHandle(currentRequest))
        {
            base.Handle(currentRequest, iterator, ref fileSystem);
        }
        else
        {
            Parse(iterator);
            fileSystem?.FileRename(_path, _newName);
        }
    }

    protected override bool CanHandle(Request currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        return currentRequest.RequestText == "rename";
    }
}