namespace CoreData.DatabasePorts;

public interface IHistoryRepository
{
    public void AddOperation(int accountNumber, decimal currentMoney);
}