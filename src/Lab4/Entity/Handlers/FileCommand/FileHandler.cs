using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.FileCommand;

public class FileHandler : CommandHandler, IBuildNestedChain
{
    private CommandHandler _fileCopyHandler = new FileCopyHandler();
    private CommandHandler _fileDeleteHandler = new FileDeleteHandler();
    private CommandHandler _fileMoveHandler = new FileMoveHandler();
    private CommandHandler _fileRenameHandler = new FileRenameHandler();
    private CommandHandler _fileShowHandler = new FileShowHandler();

    public void BuildNestedChain(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        _fileCopyHandler
            .SetNext(_fileDeleteHandler)
            .SetNext(_fileMoveHandler)
            .SetNext(_fileRenameHandler)
            .SetNext(_fileShowHandler);
        iterator.GoNext();
    }

    public override void Handle(Iterator iterator, ref SystemContext system)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        if (!CanHandle(iterator))
        {
            base.Handle(iterator, ref system);
        }
        else
        {
            BuildNestedChain(iterator);
            _fileCopyHandler.Handle(iterator, ref system);
        }
    }

    protected override bool CanHandle(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));

        return iterator.Current() == "file";
    }
}