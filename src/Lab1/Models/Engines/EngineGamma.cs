using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineGamma : BaseEngine
{
    public EngineGamma()
    {
        FuelRate = 250;
        Capacity = 500;
        Fuel = FuelType.GravitationalMatter;
    }
}