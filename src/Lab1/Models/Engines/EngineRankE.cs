using Itmo.ObjectOrientedProgramming.Lab1.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineRankE : BaseEngine
{
    private const double FuelRateValue = 5.0;
    public EngineRankE()
    {
        FuelRate = FuelRateValue;
        FuelСost = ActivePlasmaCost;
    }

    public override double? Move(double distance)
    {
        return distance / FuelRate;
    }
}