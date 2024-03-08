namespace CoreData.Entity;

public class MyTransaction
{
    public MyTransaction(int accountId, decimal money, string operationType)
    {
        AccountId = accountId;
        Money = money;
        OperationType = operationType;
    }

    public int AccountId { get; set; }
    public decimal Money { get; set; }
    public string OperationType { get; set; } = string.Empty;

    public void Show()
    {
        Console.WriteLine(AccountId + " Balance: " + Money + "Operation" + OperationType);
    }
}