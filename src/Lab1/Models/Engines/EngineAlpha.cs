using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineAlpha : BaseEngine
{
    public EngineAlpha()
    {
        FuelRate = 100;
        Capacity = 1000;
        Fuel = FuelType.GravitationalMatter;
    }
}