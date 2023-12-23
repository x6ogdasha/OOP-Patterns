using Adapters.DataBaseAdapters;
using Adapters.EntityAdapters;
using ConsoleInterface.Scenarios;
using CoreData;
using CoreData.DatabasePorts;
using Npgsql;

namespace ConsoleInterface;

public static class Program
{
    public static void Main()
    {
        string connectionInfo = new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 5432,
            Database = "MyDataBase",
            Username = "postgres",
            Password = "12345",
            SslMode = SslMode.Prefer,
        }.ConnectionString;

        IAccountRepositoryPort accountRepository = new AccountRepositoryAdapter(connectionInfo);
        IHistoryRepository historyRepository = new HistoryRepositoryAdapter(connectionInfo);
        IUserRepositoryPort userRepository = new UserRepositoryAdapter(connectionInfo);

        IUserPort userService = new UserAdapter(userRepository, accountRepository, historyRepository);
        IAdminPort adminService = new AdminAdapter(userRepository, accountRepository, historyRepository, 1111);

        BaseScenario chainOfScenario = new LoginScenario(userService, adminService);
        chainOfScenario.SetNext(new AddCashScenario())
            .SetNext(new AdminBalanceScenario())
            .SetNext(new AdminShowHistoryScenario())
            .SetNext(new CreateAccountScenario())
            .SetNext(new UserBalanceScenario())
            .SetNext(new UserShowHistoryScenario())
            .SetNext(new WithdrawScenario());

        var scenario = new ScenarioRunner(chainOfScenario, userService, adminService);
        scenario.Run();
    }
}