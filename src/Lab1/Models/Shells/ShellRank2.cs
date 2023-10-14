using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Shells;

public class ShellRank2 : BaseShell
{
    private const double HealthPointsValue = 25;
    public ShellRank2()
    {
        HealthPoints = HealthPointsValue;
        IsActive = true;
    }
}