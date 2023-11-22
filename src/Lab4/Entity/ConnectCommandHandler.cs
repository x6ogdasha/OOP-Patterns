using System;
using Itmo.ObjectOrientedProgramming.Lab4.Common;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public class ConnectCommandHandler : BaseCommandHandler, IParsePath, IParseMode
{
    public string Address { get; set; } = string.Empty;
    public WorkingMode Mode { get; set; }
    public override void Handle(Request currentRequest)
    {
        if (CanHandle(currentRequest))
        {
            ParsePath(currentRequest);
            ParseMode(currentRequest);
        }
        else
        {
            base.Handle(currentRequest);
        }
    }

    public void ParsePath(Request currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        int startIndex = currentRequest.CommandText.IndexOf('*', StringComparison.Ordinal);
        int endIndex = currentRequest.CommandText.LastIndexOf('*');

        Address = currentRequest.CommandText.Substring(startIndex + 1, endIndex - startIndex - 1);
        Console.WriteLine(Address);
    }

    public void ParseMode(Request currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        int indexOfFlag = currentRequest.CommandText.IndexOf("-m", StringComparison.Ordinal);
        string result = currentRequest.CommandText.Substring(indexOfFlag, currentRequest.CommandText.IndexOf(" ", indexOfFlag, StringComparison.Ordinal) - indexOfFlag);
        Mode = (WorkingMode)Enum.Parse(typeof(WorkingMode), result);
    }

    protected override bool CanHandle(Request currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        return currentRequest.CommandText == "connect";
    }
}