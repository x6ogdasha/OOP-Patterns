using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineOmega : BaseEngine
{
    public EngineOmega()
    {
        FuelRate = 150;
        Capacity = 1500;
        Fuel = FuelType.GravitationalMatter;
    }
}