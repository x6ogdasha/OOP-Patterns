namespace CoreData;

public interface IUserPort
{
    public decimal ShowBalance();
    public void WithdrawMoney(decimal money);
    public void AddCash(decimal money);
    public void ShowHistory();
}