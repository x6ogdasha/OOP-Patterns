using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Shells;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ships;

public class Waklas : BaseShip
{
    public Waklas()
    {
        MainEngine = new EngineRankE();
        AdditionalEngine = new EngineGamma();
        Deflector = new DeflectorRank1();
        Shell = new ShellRank2();
        Size = ShipSize.Medium;
        AntiNitrineRadiant = false;
    }
}