using Itmo.ObjectOrientedProgramming.Lab1.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineOmega : BaseEngine
{
    private const double FuelRateValue = 1500;
    public EngineOmega()
    {
        FuelRate = FuelRateValue;
        FuelСost = GravitationalMatterCost;
    }

    public override double? Move(double distance)
    {
        if (distance <= FuelRate)
        {
            return distance / FuelRate;
        }
        else
        {
            return null;
        }
    }
}