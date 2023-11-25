using System;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers.FileCommand;

public class FileMoveHandler : CommandHandler, IParse
{
    private string _sourcePath = string.Empty;
    private string _destinationPath = string.Empty;
    public Request? CurrentRequest { get; private set; }
    public void Parse(Iterator iterator)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        iterator.GoNext();
        _sourcePath = iterator.Current();
        iterator.GoNext();
        _destinationPath = iterator.Current();
        if (CurrentRequest is not null)
        {
            CurrentRequest.FirstPath = _sourcePath;
            CurrentRequest.SecondPath = _destinationPath;
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
            CurrentRequest.CurrentHandler = new FileMoveHandler();
            Parse(iterator);
            fileSystem?.FileMove(_sourcePath, _destinationPath);
        }
    }

    protected override bool CanHandle(Request currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        return currentRequest.RequestText == "move";
    }
}