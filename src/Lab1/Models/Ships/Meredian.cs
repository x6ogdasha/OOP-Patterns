using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Shells;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ships;

public class Meredian : BaseShip
{
    public Meredian()
    {
        MainEngine = new EngineRankE();
        Deflector = new DeflectorRank2();
        Shell = new ShellRank2();
        Size = ShipSize.Medium;
        AntiNitrineRadiant = true;
    }
}