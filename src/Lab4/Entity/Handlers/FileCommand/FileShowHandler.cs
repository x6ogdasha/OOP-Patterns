using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.Flags;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.FileCommand;

public class FileShowHandler : CommandHandler, IParse
{
    private Dictionary<string, string> _flags = new Dictionary<string, string>()
    {
        { "-m", string.Empty },
    };
    public string Path { get; private set; } = string.Empty;
    public void Parse(Iterator iterator, ref SystemContext system)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        iterator.GoNext();
        Path = iterator.Current();
        iterator.GoNext();

        FlagHandler modeHandler = new ModeHandler();
        var chainOfFlags = new CreateChainOfFlags(modeHandler);
        chainOfFlags.Create();
        modeHandler.Handle(iterator, _flags, ref system);
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
            system.LastHandler = new FileShowHandler();
            system.FileSystem?.FileShow(Path);
        }
    }

    protected override bool CanHandle(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));

        return iterator.Current() == "show";
    }
}