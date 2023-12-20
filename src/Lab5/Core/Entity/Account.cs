namespace Core.Entity;

public class Account
{
    public Account(string number, decimal money)
    {
        Number = number;
        Money = money;
    }

    public string Number { get; set; } = string.Empty;
    public decimal Money { get; set; }
}