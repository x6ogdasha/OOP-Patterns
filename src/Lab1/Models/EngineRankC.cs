using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class EngineRankC : BaseEngine
{
    public EngineRankC()
    {
        FuelRate = 1.5;
        Capacity = 100;
        Fuel = FuelType.ActivePlasma;
    }

    public override void Run()
    {
        IsRunning = true;
        Capacity -= 0.5;
    }
}