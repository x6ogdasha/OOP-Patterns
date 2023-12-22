using CoreData;
using CoreData.DatabasePorts;
using Npgsql;

namespace Adapters.DataBaseAdapters;

public class UserRepositoryAdapter : IUserRepositoryPort
{
    public User? FindById(int id)
    {
        const string sql = """
                           select Name
                           from "Schema"."Users"
                           where UserID = @accountId
                           """;
        using var connection = new NpgsqlConnection(new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 5432,
            Username = "postgres",
            Password = "12345",
            SslMode = SslMode.Prefer,
        }.ConnectionString);
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
        using var connection = new NpgsqlConnection(new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 5432,
            Username = "postgres",
            Password = "123456",
            SslMode = SslMode.Prefer,
        }.ConnectionString);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("name", name);
        command.Parameters.AddWithValue("role", role);
        command.Parameters.AddWithValue("password", password);
    }
}