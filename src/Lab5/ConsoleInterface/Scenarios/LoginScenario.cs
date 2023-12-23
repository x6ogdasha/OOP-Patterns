using ConsoleInterface.Services;
using CoreData;
using CoreData.Common;

namespace ConsoleInterface.Scenarios;

public class LoginScenario : BaseScenario
{
    private readonly IUserPort _userService;
    private readonly IAdminPort _adminService;
    private readonly Service _service = new Service();

    public LoginScenario(IUserPort userService, IAdminPort adminService)
    {
        _userService = userService;
        _adminService = adminService;
    }

    public override void Handle(string command, IUserPort userService, IAdminPort adminService)
    {
        if (command == "login")
        {
            Run(userService, adminService);
            return;
        }

        base.Handle(command, userService, adminService);
    }

    public override void Run(IUserPort userService, IAdminPort adminService)
    {
        Console.WriteLine("Enter Id: ");
        string? idString = Console.ReadLine();

        int id = _service.ParsePassword(idString);
        Console.WriteLine("Enter Password: ");
        string? passwordString = Console.ReadLine();
        int password = _service.ParsePassword(passwordString);

        if (idString == "Admin")
        {
            adminService?.CheckForPermissions(password);
        }

        LoginResult result = _userService.Login(id, password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
            _ => throw new IncorrectLoginException(),
        };
        Console.WriteLine(message);
    }
}