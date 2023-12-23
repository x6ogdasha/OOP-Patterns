using CoreData;
using CoreData.DatabasePorts;
using Npgsql;

namespace Adapters.DataBaseAdapters;

public class UserRepositoryAdapter : IUserRepositoryPort
{
    public UserRepositoryAdapter(string connectionInfo)
    {
        ConnectionInfo = connectionInfo;
    }

    public string ConnectionInfo { get; private set; }
    public User? FindById(int id)
    {
        const string sql = """
                           select Name, UserId, Password
                           from "Schema"."Users"
                           where UserID = @accountId
                           """;
        using var connection = new NpgsqlConnection(ConnectionInfo);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);

        using NpgsqlDataReader reader = command.ExecuteReader();

        string userName = reader.GetString(0);
        int userId = reader.GetInt32(1);
        int userPassword = reader.GetInt32(3);

        return new User(userName, userId, userPassword);
    }

    public void AddNewUser(string name, UserRole role, int password)
    {
        const string sql = """
                           insert into "Schema".Users
                           values (@name, @role, @password)
                           """;
        using var connection = new NpgsqlConnection(ConnectionInfo);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("name", name);
        command.Parameters.AddWithValue("role", role);
        command.Parameters.AddWithValue("password", password);
    }

    public int FindLastUserId()
    {
        const string sql = """
                           select UserId
                           from "Schema".Users
                           where UserId = MAX(UserId)
                           """;
        using var connection = new NpgsqlConnection(ConnectionInfo);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);

        using NpgsqlDataReader reader = command.ExecuteReader();
        int userId = reader.GetInt32(1);

        return userId;
    }

    public string? GetRoleById(int id)
    {
        const string sql = """
                           select Role
                           from "Schema".Users
                           where UserId = @id
                           """;
        using var connection = new NpgsqlConnection(ConnectionInfo);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);
        using NpgsqlDataReader reader = command.ExecuteReader();
        string userRole = reader.GetString(0);

        return userRole;
    }
}