namespace CoreData;

public interface IAdminPort
{
    public void ShowBalance(User user);
    public void ShowHistory(User user);
    public void CreateUser(int id, string name, int password, UserRole role);
}