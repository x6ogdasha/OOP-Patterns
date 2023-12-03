using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.Flags;

public class ModeHandler : FlagHandler
{
    private string _currentFlag = string.Empty;
    private string _currentMode = string.Empty;
    public override void Handle(Iterator iterator, Dictionary<string, string> flags, ref SystemContext system)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        if (flags is null) throw new ArgumentNullException(nameof(flags));

        if (!CanHandle(iterator))
        {
            base.Handle(iterator, flags, ref system);
        }
        else
        {
            _currentFlag = iterator.Current();
            iterator.GoNext();
            _currentMode = iterator.Current();
            flags[_currentFlag] = _currentMode;
            if (_currentMode == "local")
            {
                system = new SystemContext();
                system.FileSystem = new LocalFileSystem();
            }
        }
    }

    protected override bool CanHandle(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        return iterator.Current() == "-m";
    }
}