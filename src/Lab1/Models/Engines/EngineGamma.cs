using Itmo.ObjectOrientedProgramming.Lab1.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineGamma : BaseEngine
{
    private const double FuelRateValue = 250;
    public EngineGamma()
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