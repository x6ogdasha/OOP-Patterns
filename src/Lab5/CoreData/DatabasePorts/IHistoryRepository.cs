namespace CoreData.DatabasePorts;

public interface IHistoryRepository
{
    public void AddOperation(int accountId, string operationType, decimal currentMoney);
}