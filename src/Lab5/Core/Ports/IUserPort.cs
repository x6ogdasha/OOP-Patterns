namespace Core.Ports;

public interface IUserPort
{
    public void ShowBalance();
    public void WithdrawMoney(decimal money);
    public void AddCash(decimal money);
    public void ShowHistory();
}