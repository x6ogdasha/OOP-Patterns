namespace CoreData.Common;

public class NotEnoughMoneyException : Exception
{
    public NotEnoughMoneyException(string message)
        : base(message)
    {
    }

    public NotEnoughMoneyException()
    {
    }

    public NotEnoughMoneyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}