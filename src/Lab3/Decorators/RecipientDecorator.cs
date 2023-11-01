using Itmo.ObjectOrientedProgramming.Lab3.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab3.Decorators;

public class RecipientDecorator : Recipient
{
    public RecipientDecorator(Recipient recipient)
    {
        CurrentRecipient = recipient;
    }

    public Recipient CurrentRecipient { get; protected set; }
}