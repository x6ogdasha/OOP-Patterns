namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class Message
{
    public Message()
    {
        Title = string.Empty;
        Body = string.Empty;
    }

    public string Title { get; protected set; }
    public string Body { get; protected set; }
    public int Importance { get; protected set; }
}