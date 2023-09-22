using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Shells;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ships;

public class Stella : BaseShip
{
    public Stella()
    {
        MainEngine = new EngineRankC();
        AdditionalEngine = new EngineAlpha();
        Deflector = new DeflectorRank1();
        Shell = new ShellRank1();
        Size = ShipSize.Small;
        AntiNitrineRadiant = false;
    }
}