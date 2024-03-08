namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class Thread
{
    private readonly Logger _logger = new Logger();
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
        _logger.Log("Сообщение направлено адресату");
    }
}