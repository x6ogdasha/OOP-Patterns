using CoreData.Entity;

namespace CoreData.DatabasePorts;

public interface IAccountRepositoryPort
{
    public Account? FindById(int userId);
    public void UpdateMoney(int accountId, decimal money);
    public void CreateAccount(decimal money, int userId);
}