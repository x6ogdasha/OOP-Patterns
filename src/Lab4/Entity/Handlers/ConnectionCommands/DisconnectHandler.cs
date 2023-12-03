using System;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.ConnectionCommands;

public class DisconnectHandler : CommandHandler
{
    public override void Handle(Iterator iterator, ref SystemContext system)
    {
        if (CanHandle(iterator))
        {
            system?.FileSystem?.Disconnect();
        }
        else
        {
            base.Handle(iterator, ref system);
        }
    }

    protected override bool CanHandle(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));

        return iterator.Current() == "disconnect";
    }
}