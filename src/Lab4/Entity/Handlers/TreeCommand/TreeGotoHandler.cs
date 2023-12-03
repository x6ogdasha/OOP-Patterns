using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.TreeCommand;

public class TreeGotoHandler : CommandHandler, IParse
{
    public string Path { get; private set; } = string.Empty;

    public void Parse(Iterator iterator, ref SystemContext system)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));

        iterator.GoNext();
        Path = iterator.Current();
    }

    public override void Handle(Iterator iterator, ref SystemContext system)
    {
        if (system is null) throw new ArgumentNullException(nameof(system));
        if (!CanHandle(iterator))
        {
            base.Handle(iterator, ref system);
        }
        else
        {
            Parse(iterator, ref system);

            system.LastHandler = new TreeGotoHandler();
            system.FileSystem?.TreeGoto(Path);
        }
    }

    protected override bool CanHandle(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));

        return iterator.Current() == "goto";
    }
}