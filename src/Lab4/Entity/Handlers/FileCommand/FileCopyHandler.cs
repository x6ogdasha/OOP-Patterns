using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.FileCommand;

public class FileCopyHandler : CommandHandler, IParse
{
    public string SourcePath { get; private set; } = string.Empty;
    public string DestinationPath { get; private set; } = string.Empty;

    public void Parse(Iterator iterator, ref SystemContext system)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        iterator.GoNext();
        SourcePath = iterator.Current();
        iterator.GoNext();
        DestinationPath = iterator.Current();
    }

    public override void Handle(Iterator iterator, ref SystemContext system)
    {
        if (!CanHandle(iterator))
        {
            base.Handle(iterator, ref system);
        }
        else
        {
            Parse(iterator, ref system);
            if (system is null) return;
            system.LastHandler = new FileCopyHandler();
            system.FileSystem?.FileCopy(SourcePath, DestinationPath);
        }
    }

    protected override bool CanHandle(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));

        return iterator.Current() == "copy";
    }
}