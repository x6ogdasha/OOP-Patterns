using CoreData;

namespace ConsoleInterface.Scenarios;

public class ScenarioRunner
{
    private readonly BaseScenario _scenarioChain;
    private readonly IUserPort _userService;
    private readonly IAdminPort _adminService;

    public ScenarioRunner(BaseScenario scenarioChain, IUserPort userService, IAdminPort adminService)
    {
        _scenarioChain = scenarioChain;
        _userService = userService;
        _adminService = adminService;
    }

    public void Run()
    {
        string? startCommand = string.Empty;

        while (startCommand != "stop")
        {
            Console.WriteLine("Waiting for command: ");
            startCommand = Console.ReadLine();
            if (startCommand is not null) _scenarioChain.Handle(startCommand, _userService, _adminService);
        }
    }
}