using CoreData.Entity;

namespace CoreData.DatabasePorts;

public interface IAccountRepositoryPort
{
    public IList<Account>? FindById(int accountId);
    public void UpdateMoney(int accountId, decimal money);
}