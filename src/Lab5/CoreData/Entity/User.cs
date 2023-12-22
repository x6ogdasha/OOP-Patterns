namespace CoreData;

public class User
{
    public User(string name, int id, UserRole role)
    {
        Name = name;
        AccountId = id;
        Role = role;
    }

    public User(string name, int id)
    {
        Name = name;
        AccountId = id;
    }

    public string Name { get; set; } = string.Empty;
    public int AccountId { get; set; }
    public UserRole Role { get; set; }
}