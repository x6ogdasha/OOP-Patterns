using Itmo.ObjectOrientedProgramming.Lab1.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineOmega : BaseEngine
{
    public EngineOmega()
    {
        FuelRate = 1500;
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