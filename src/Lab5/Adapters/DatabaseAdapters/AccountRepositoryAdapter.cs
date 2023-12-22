using CoreData.DatabasePorts;
using CoreData.Entity;
using Npgsql;

namespace Adapters.DataBaseAdapters;

public class AccountRepositoryAdapter : IAccountRepositoryPort
{
    public Account? FindById(int userId)
    {
        const string sql = """
                           select AccountID, Money, UserID
                           from "Schema"."Accounts"
                           where UserID = @userId
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
        command.Parameters.AddWithValue("userId", userId);

        using NpgsqlDataReader reader = command.ExecuteReader();
        int currentAccountId = reader.GetInt32(0);
        decimal currentMoney = reader.GetInt32(1);
        int currentUserId = reader.GetInt32(2);

        return new Account(currentAccountId, currentMoney, currentUserId);
    }

    public void UpdateMoney(int accountId, decimal money)
    {
        const string sql = """
                           update "Schema".Accounts
                           set Money = @money
                           where AccountId = @accountId
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
        command.Parameters.AddWithValue("accountId", accountId);
        command.Parameters.AddWithValue("money", money);
    }

    public void CreateAccount(decimal money, int userId)
    {
        const string sql = """
                           insert into "Schema".Accounts ("Money", "UserID")
                           values (@money, @userId)
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
        command.Parameters.AddWithValue("money", money);
        command.Parameters.AddWithValue("userId", userId);
    }
}