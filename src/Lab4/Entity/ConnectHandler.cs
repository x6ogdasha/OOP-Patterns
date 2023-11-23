using System;
using Itmo.ObjectOrientedProgramming.Lab4.Common;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public class ConnectHandler : CommandHandler
{
    private string _flag = string.Empty;

    public string Address { get; set; } = string.Empty;
    public override void Handle(string currentRequest, Iterator iterator, Properties properties)
    {
        if (iterator is null) throw new ArgumentNullException(nameof(iterator));
        if (properties is null) throw new ArgumentNullException(nameof(properties));

        if (!CanHandle(currentRequest)) base.Handle(currentRequest, iterator, properties);

        iterator.GoNext();
        Address = iterator.Current();
        iterator.GoNext();
        _flag = iterator.Current();
        iterator.GoNext();

        if (_flag == "-m") properties.Mode = (WorkingMode)Enum.Parse(typeof(WorkingMode), iterator.Current());
    }

    protected override bool CanHandle(string currentRequest)
    {
        if (currentRequest is null) throw new ArgumentNullException(nameof(currentRequest));
        return currentRequest == "connect";
    }
}