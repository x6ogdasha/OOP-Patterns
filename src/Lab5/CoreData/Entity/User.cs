namespace CoreData;

public class User
{
    public User(string name, int id, UserRole role, int password)
    {
        Name = name;
        AccountId = id;
        Role = role;
        Password = password;
    }

    public User(string name, int id, int password)
    {
        Name = name;
        AccountId = id;
        Password = password;
    }

    public string Name { get; set; } = string.Empty;
    public int AccountId { get; set; }
    public int Password { get; set; }
    public UserRole Role { get; set; }
}