using CoreData;

namespace ConsoleInterface.Scenarios;

public class UserBalanceScenario : BaseScenario
{
    public override void Handle(string command, IUserPort userService, IAdminPort adminService)
    {
        if (command == "MyBalance")
        {
            Run(userService, adminService);
            return;
        }

        base.Handle(command, userService, adminService);
    }

    public override void Run(IUserPort userService, IAdminPort adminService)
    {
        userService?.ShowBalance();
    }
}