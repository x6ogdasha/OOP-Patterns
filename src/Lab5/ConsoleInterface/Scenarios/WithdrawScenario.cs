using ConsoleInterface.Services;
using CoreData;

namespace ConsoleInterface.Scenarios;

public class WithdrawScenario : BaseScenario
{
    private Service _service = new Service();
    public override void Handle(string command, IUserPort userService, IAdminPort adminService)
    {
        if (command == "withdraw")
        {
            Run(userService, adminService);
            return;
        }

        base.Handle(command, userService, adminService);
    }

    public override void Run(IUserPort userService, IAdminPort adminService)
    {
        string? moneyString = Console.ReadLine();
        decimal money = _service.ParsePassword(moneyString);
        userService?.WithdrawMoney(money);
    }
}