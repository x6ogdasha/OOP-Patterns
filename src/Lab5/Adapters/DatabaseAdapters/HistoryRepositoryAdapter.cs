using CoreData.DatabasePorts;
using CoreData.Entity;
using Npgsql;

namespace Adapters.DataBaseAdapters;

public class HistoryRepositoryAdapter : IHistoryRepository
{
    public HistoryRepositoryAdapter(string connectionInfo)
    {
        ConnectionInfo = connectionInfo;
    }

    public string ConnectionInfo { get; private set; }
    public void AddOperation(int accountId, string operationType, decimal currentMoney)
    {
        const string sql = """
                           insert into "Bank"."History"
                           values (@accountId, @operationType, @currentMoney)
                           """;
        using var connection = new NpgsqlConnection(ConnectionInfo);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("accountId", accountId);
        command.Parameters.AddWithValue("money", currentMoney);
    }

    public IList<MyTransaction> GetTransactionHistory(int userId)
    {
        IList<MyTransaction> result = new List<MyTransaction>();
        const string sql = """
                           select "AccountID", "CurrentMoney", "OperationType"
                           from "Bank"."History"
                           where "UserID" = @userId
                           """;
        using var connection = new NpgsqlConnection(ConnectionInfo);
        connection.Open();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("userId", userId);

        using NpgsqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int currentAccountId = reader.GetInt32(0);
            decimal money = reader.GetInt32(1);
            string operation = reader.GetString(3);
            result.Add(new MyTransaction(currentAccountId, money, operation));
        }

        return result;
    }
}