namespace CoreData;

public interface IAdminPort
{
    public decimal ShowBalance(User user);
    public void ShowHistory(User user);
    public void CreateUser(string name, int password, UserRole role);
}