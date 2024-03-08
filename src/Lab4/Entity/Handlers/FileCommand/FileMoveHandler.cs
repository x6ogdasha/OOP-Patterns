using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.FileCommand;

public class FileMoveHandler : CommandHandler, IParse
{
    public string SourcePath { get; private set; } = string.Empty;
    public string DestinationPath { get; private set; } = string.Empty;
    public Request CurrentRequest { get; private set; } = new Request();
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
        if (system is null) throw new ArgumentNullException(nameof(system));
        if (!CanHandle(iterator))
        {
            base.Handle(iterator, ref system);
        }
        else
        {
            Parse(iterator, ref system);
            system.LastHandler = new FileMoveHandler();
            system.FileSystem?.FileMove(SourcePath, DestinationPath);
        }
    }

    protected override bool CanHandle(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));

        return iterator.Current() == "move";
    }
}