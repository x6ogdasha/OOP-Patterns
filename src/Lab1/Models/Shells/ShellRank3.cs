using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Shells;

public class ShellRank3 : BaseShell
{
    private const double HealthPointsValue = 100;
    public ShellRank3()
    {
        HealthPoints = HealthPointsValue;
        IsActive = true;
    }
}