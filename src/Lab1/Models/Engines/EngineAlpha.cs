using Itmo.ObjectOrientedProgramming.Lab1.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineAlpha : BaseEngine
{
    private const double FuelRateValue = 100;
    public EngineAlpha()
    {
        FuelRate = FuelRateValue;
        FuelСost = GravitationalMatterCost;
    }

    public override double? Move(double distance)
    {
        if (distance <= FuelRate)
            return distance / FuelRate;
        else
            return null;
    }
}