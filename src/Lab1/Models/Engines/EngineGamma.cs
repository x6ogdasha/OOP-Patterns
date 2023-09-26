using Itmo.ObjectOrientedProgramming.Lab1.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineGamma : BaseEngine
{
    public EngineGamma()
    {
        FuelRate = 250;
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