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
                           select *
                           from "Bank"."Users"
                           where "UserID" = @id
                           """;
        using var connection = new NpgsqlConnection(ConnectionInfo);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);

        using NpgsqlDataReader reader = command.ExecuteReader();

        reader.Read();
        string userName = reader.GetString(0);
        int userId = reader.GetInt32(1);
        int userPassword = reader.GetInt32(2);

        return new User(userName, userId, userPassword);
    }

    public void AddNewUser(string name, UserRole role, int password)
    {
        const string sql = """
                           insert into "Bank"."Users" ("Name", "Role", "Password")
                           values (@name, @role, @password)
                           """;
        using var connection = new NpgsqlConnection(ConnectionInfo);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Parameters.AddWithValue("name", name);
        command.Parameters.AddWithValue("role", role);
        command.Parameters.AddWithValue("password", password);
    }

    public int FindLastUserId()
    {
        const string sql = """
                           select  "UserID"
                           from "Bank"."Users"
                           group by "UserID"
                           order by "UserID" desc
                           """;
        using var connection = new NpgsqlConnection(ConnectionInfo);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();
        reader.Read();
        int userId = reader.GetInt32(1);

        return userId;
    }

    public string? GetRoleById(int id)
    {
        const string sql = """
                           select "Role"
                           from "Bank"."Users"
                           where "UserID" = @id
                           """;
        using var connection = new NpgsqlConnection(ConnectionInfo);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);
        using NpgsqlDataReader reader = command.ExecuteReader();
        reader.Read();
        string userRole = reader.GetString(0);

        return userRole;
    }
}