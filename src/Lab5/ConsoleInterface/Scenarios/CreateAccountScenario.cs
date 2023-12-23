using ConsoleInterface.Services;
using CoreData;

namespace ConsoleInterface.Scenarios;

public class CreateAccountScenario : BaseScenario
{
    private Service _service = new Service();
    public override void Handle(string command, IUserPort userService, IAdminPort adminService)
    {
        if (command == "create")
        {
            Run(userService, adminService);
            return;
        }

        base.Handle(command, userService, adminService);
    }

    public override void Run(IUserPort userService, IAdminPort adminService)
    {
        if (adminService is null) throw new ArgumentNullException(nameof(adminService));
        Console.WriteLine("Ener name: ");
        string? name = Console.ReadLine();
        Console.WriteLine("Enter password");
        string? passwordString = Console.ReadLine();
        int password = _service.ParsePassword(passwordString);
        if (name is not null) adminService.CreateUser(name, password, UserRole.Common);
    }
}