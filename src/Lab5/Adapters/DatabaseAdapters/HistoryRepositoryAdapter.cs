using CoreData.DatabasePorts;
using Npgsql;

namespace Adapters.DataBaseAdapters;

public class HistoryRepositoryAdapter : IHistoryRepository
{
    public void AddOperation(int accountId, string operationType, decimal currentMoney)
    {
        const string sql = """
                           insert into History
                           values (@accountId, @operationType, @currentMoney)
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
        command.Parameters.AddWithValue("accountId", accountId);
        command.Parameters.AddWithValue("money", currentMoney);
    }
}