namespace CoreData;

public interface IAdminPort
{
    public decimal ShowBalance(int id);
    public void ShowHistory(int id);
    public void CreateUser(string name, int password, UserRole role);
    public void CheckForPermissions(int password);
}