namespace CoreData.Common;

public class IncorrectLoginException : Exception
{
    public IncorrectLoginException(string message)
        : base(message)
    {
    }

    public IncorrectLoginException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public IncorrectLoginException()
    {
    }
}