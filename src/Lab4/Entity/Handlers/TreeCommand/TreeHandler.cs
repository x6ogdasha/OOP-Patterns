using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.TreeCommand;

public class TreeHandler : CommandHandler, IBuildNestedChain
{
    private CommandHandler _treeGotoHandler = new TreeGotoHandler();
    private CommandHandler _treeListHandler = new TreeListHandler();

    public void BuildNestedChain(Request currentRequest, Iterator iterator)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        _treeGotoHandler.SetNext(_treeListHandler);

        iterator.GoNext();
        currentRequest.RequestText = iterator.Current();
    }

    public override void Handle(Request currentRequest, Iterator iterator, IFileSystem? fileSystem)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        if (!CanHandle(currentRequest)) base.Handle(currentRequest, iterator, fileSystem);

        BuildNestedChain(currentRequest, iterator);
        _treeGotoHandler.Handle(currentRequest, iterator, fileSystem);
    }

    protected override bool CanHandle(Request currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        return currentRequest.RequestText == "tree";
    }
}