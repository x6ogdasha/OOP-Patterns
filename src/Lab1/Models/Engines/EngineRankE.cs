using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;

public class EngineRankE : BaseEngine
{
    public EngineRankE()
    {
        FuelRate = 5.0;
        Capacity = 500;
        Fuel = FuelType.ActivePlasma;
    }

    public override void Run()
    {
        IsRunning = true;
        Capacity -= 1;
    }
}