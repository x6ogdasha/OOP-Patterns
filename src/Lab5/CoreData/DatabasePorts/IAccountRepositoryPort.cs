using CoreData.Entity;

namespace CoreData.DatabasePorts;

public interface IAccountRepositoryPort
{
    public Account? FindById(int accountId);
    public void UpdateMoney(int accountId, decimal money);
}