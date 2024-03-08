using CoreData;

namespace ConsoleInterface.Scenarios;

public abstract class BaseScenario
{
    public BaseScenario? NextScenario { get; set; }

    public BaseScenario SetNext(BaseScenario scenario)
    {
        NextScenario = scenario;
        return NextScenario;
    }

    public virtual void Handle(string command, IUserPort userService, IAdminPort adminService)
    {
        NextScenario?.Handle(command, userService, adminService);
    }

    public abstract void Run(IUserPort userService, IAdminPort adminService);
}