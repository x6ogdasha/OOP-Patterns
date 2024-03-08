using Itmo.ObjectOrientedProgramming.Lab1.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineRankC : BaseEngine
{
    private const double FuelRateValue = 1.5;
    public EngineRankC()
    {
        FuelRate = FuelRateValue;
        FuelСost = ActivePlasmaCost;
    }

    public override double? Move(double distance)
    {
        return distance / FuelRate;
    }
}