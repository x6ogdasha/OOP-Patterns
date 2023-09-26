using Itmo.ObjectOrientedProgramming.Lab1.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineAlpha : BaseEngine
{
    public EngineAlpha()
    {
        FuelRate = 100;
        FuelСost = GravitationalMatterCost;
    }

    public override double Move(double distance)
    {
        if (distance <= FuelRate)
        {
            return distance / FuelRate;
        }
        else
        {
            return -1;
        }
    }
}