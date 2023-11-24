using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.FileCommand;

public class FileHandler : CommandHandler, IBuildNestedChain
{
    private CommandHandler _fileCopyHandler = new FileCopyHandler();
    private CommandHandler _fileDeleteHandler = new FileDeleteHandler();
    private CommandHandler _fileMoveHandler = new FileMoveHandler();
    private CommandHandler _fileRenameHandler = new FileRenameHandler();
    private CommandHandler _fileShowHandler = new FileShowHandler();

    public void BuildNestedChain(Request currentRequest, Iterator iterator)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        _fileCopyHandler
            .SetNext(_fileDeleteHandler)
            .SetNext(_fileMoveHandler)
            .SetNext(_fileRenameHandler)
            .SetNext(_fileShowHandler);
        iterator.GoNext();
        currentRequest.RequestText = iterator.Current();
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
            BuildNestedChain(currentRequest, iterator);
            _fileCopyHandler.Handle(currentRequest, iterator, ref fileSystem);
        }
    }

    protected override bool CanHandle(Request currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        return currentRequest.RequestText == "file";
    }
}