namespace CoreData.Entity;

public class Account
{
    public Account(int accountId, decimal money, int userId)
    {
        AccountId = accountId;
        Money = money;
        UserId = userId;
    }

    public int AccountId { get; set; }
    public decimal Money { get; set; }
    public int UserId { get; set; }
}