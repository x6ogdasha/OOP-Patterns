namespace Core.Entity;

public class User
{
    public User(int id, string name, UserRole role)
    {
        Id = id;
        Name = name;
        Role = role;
    }

    public decimal Id { get; set; }
    public decimal Pin { get; }
    public string Name { get; } = string.Empty;
    public UserRole Role { get; }
}