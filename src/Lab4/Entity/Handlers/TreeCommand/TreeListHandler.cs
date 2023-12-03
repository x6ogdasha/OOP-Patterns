using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.Flags;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.TreeCommand;

public class TreeListHandler : CommandHandler, IParse
{
    private Dictionary<string, string> _flags = new Dictionary<string, string>()
    {
        { "-d", string.Empty },
    };
    public Request? CurrentRequest { get; private set; }

    public void Parse(Iterator iterator, ref SystemContext system)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
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
            system.LastHandler = new TreeListHandler();
            string depth = GetDepth();
            system.FileSystem?.TreeList(int.Parse(depth, new NumberFormatInfo()));
        }
    }

    protected override bool CanHandle(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));

        return iterator.Current() == "list";
    }

    private string GetDepth()
    {
        KeyValuePair<string, string> current = _flags.FirstOrDefault(x => x.Key == "-d");
        return current.Value;
    }
}