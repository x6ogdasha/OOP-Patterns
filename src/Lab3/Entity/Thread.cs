namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class Thread
{
    public Thread(Recipient recipient, string name)
    {
        CurrentRecipient = recipient;
        Name = name;
    }

    public string Name { get; protected set; }
    public Recipient CurrentRecipient { get; protected set; }

    public void SendToRecipient(Message message)
    {
        CurrentRecipient.Receive(message);
    }
}