namespace CoreData.DatabasePorts;

public interface IAccountRepositoryPort
{
    public void FindByNumber(int number);
    public void UpdateMoney(decimal money);
}