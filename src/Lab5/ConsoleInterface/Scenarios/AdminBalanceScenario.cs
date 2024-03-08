using ConsoleInterface.Services;
using CoreData;

namespace ConsoleInterface.Scenarios;

public class AdminBalanceScenario : BaseScenario
{
    private Service _service = new Service();
    public override void Handle(string command, IUserPort userService, IAdminPort adminService)
    {
        if (command == "UserBalance")
        {
            Run(userService, adminService);
            return;
        }

        base.Handle(command, userService, adminService);
    }

    public override void Run(IUserPort userService, IAdminPort adminService)
    {
        string? idString = Console.ReadLine();
        int id = _service.ParsePassword(idString);
        adminService?.ShowBalance(id);
    }
}