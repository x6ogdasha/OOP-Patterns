using Core.Entity;

namespace Core.Ports;

public interface IAdminPort
{
    public void ShowBalance(User user);
    public void ShowHistory(User user);
    public void CreateUser(int id, string name, UserRole role);
}