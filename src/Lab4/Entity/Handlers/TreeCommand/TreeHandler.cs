using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.TreeCommand;

public class TreeHandler : CommandHandler, IBuildNestedChain
{
    private CommandHandler _treeGotoHandler = new TreeGotoHandler();
    private CommandHandler _treeListHandler = new TreeListHandler();

    public void BuildNestedChain(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        _treeGotoHandler.SetNext(_treeListHandler);

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
            _treeGotoHandler.Handle(iterator, ref system);
        }
    }

    protected override bool CanHandle(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));

        return iterator.Current() == "tree";
    }
}