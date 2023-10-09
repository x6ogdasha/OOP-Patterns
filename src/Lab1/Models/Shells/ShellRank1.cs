using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Shells;

public class ShellRank1 : BaseShell
{
    private const double HealthPointsValue = 5;
    public ShellRank1()
    {
        HealthPoints = HealthPointsValue;
        IsActive = true;
    }
}