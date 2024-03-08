using CoreData.DatabasePorts;
using CoreData.Entity;
using Npgsql;

namespace Adapters.DataBaseAdapters;

public class AccountRepositoryAdapter : IAccountRepositoryPort
{
    public AccountRepositoryAdapter(string connectionInfo)
    {
        ConnectionInfo = connectionInfo;
    }

    public string ConnectionInfo { get; private set; }
    public Account? FindById(int userId)
    {
        const string sql = """
                           select *
                           from "Bank"."Accounts"
                           where "UserID" = @userId
                           """;
        using var connection = new NpgsqlConnection(ConnectionInfo);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("userId", userId);

        using NpgsqlDataReader reader = command.ExecuteReader();
        reader.Read();
        int currentAccountId = reader.GetInt32(0);
        decimal currentMoney = reader.GetInt32(1);
        int currentUserId = reader.GetInt32(2);

        return new Account(currentAccountId, currentMoney, currentUserId);
    }

    public void UpdateMoney(int userId, decimal money)
    {
        const string sql = """
                           update "Bank"."Accounts"
                           set "Money" = @money
                           where "UserID" = @userId
                           """;
        using var connection = new NpgsqlConnection(ConnectionInfo);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("userId", userId);
        command.Parameters.AddWithValue("money", money);
        command.ExecuteReader();
    }

    public void CreateAccount(decimal money, int userId)
    {
        const string sql = """
                           insert into "Bank"."Accounts" ("Money", "UserID")
                           values (@money, @userId)
                           """;
        using var connection = new NpgsqlConnection(ConnectionInfo);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();
        command.Parameters.AddWithValue("money", money);
        command.Parameters.AddWithValue("userId", userId);
    }
}