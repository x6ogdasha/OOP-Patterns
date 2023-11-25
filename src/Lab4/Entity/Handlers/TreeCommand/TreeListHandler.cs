using System;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.TreeCommand;

public class TreeListHandler : CommandHandler, IParse
{
    private int _depth;
    private string _flag = string.Empty;
    public Request? CurrentRequest { get; private set; }
    public void Parse(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        iterator.GoNext();
        _flag = iterator.Current();
        iterator.GoNext();
        _depth = int.Parse(iterator.Current(), new NumberFormatInfo());
        if (CurrentRequest is not null)
        {
            CurrentRequest.Flag = _flag;
            CurrentRequest.Depth = _depth;
        }
    }

    public override void Handle(Request currentRequest, Iterator iterator, ref IFileSystem? fileSystem)
    {
        if (!CanHandle(currentRequest))
        {
            base.Handle(currentRequest, iterator, ref fileSystem);
        }
        else
        {
            CurrentRequest = currentRequest;
            CurrentRequest.CurrentHandler = new TreeListHandler();
            Parse(iterator);
            fileSystem?.TreeList(_depth);
        }
    }

    protected override bool CanHandle(Request currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        return currentRequest.RequestText == "list";
    }
}