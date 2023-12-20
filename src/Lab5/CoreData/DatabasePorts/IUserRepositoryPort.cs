namespace CoreData.DatabasePorts;

public interface IUserRepositoryPort
{
    public void FindById(int id);
    public void AddNewUser(User user);
}