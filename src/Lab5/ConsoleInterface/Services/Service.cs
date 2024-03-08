using System.Globalization;

namespace ConsoleInterface.Services;

public class Service : IParsePassword
{
    public int ParsePassword(string? password)
    {
        if (password is not null) return int.Parse(password, new NumberFormatInfo());
        return -1;
    }
}