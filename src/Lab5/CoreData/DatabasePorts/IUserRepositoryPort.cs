namespace CoreData.DatabasePorts;

public interface IUserRepositoryPort
{
    public User? FindById(int id);
    public void AddNewUser(string name, UserRole role, int password);
    public int FindLastUserId();
}