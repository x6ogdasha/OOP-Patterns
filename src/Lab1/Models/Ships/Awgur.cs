using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Shells;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ships;

public class Awgur : BaseShip
{
    public Awgur()
    {
        MainEngine = new EngineRankE();
        AdditionalEngine = new EngineAlpha();
        Deflector = new DeflectorRank3();
        Shell = new ShellRank3();
        Size = ShipSize.Large;
        AntiNitrineRadiant = false;
    }
}