using Itmo.ObjectOrientedProgramming.Lab1.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineRankE : BaseEngine
{
    public EngineRankE()
    {
        FuelRate = 5.0;
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