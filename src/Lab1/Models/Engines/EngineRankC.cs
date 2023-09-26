using Itmo.ObjectOrientedProgramming.Lab1.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineRankC : BaseEngine
{
    public EngineRankC()
    {
        FuelRate = 1.5;
        FuelСost = ActivePlasmaCost;
    }

    public override void Run()
    {
        IsRunning = true;
    }

    public override double Move(double distance)
    {
        return distance / FuelRate;
    }
}