using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Shells;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ships;

public class PleasureShuttle : BaseShip
{
    public PleasureShuttle()
    {
        MainEngine = new EngineRankC();
        Shell = new ShellRank1();
        Size = ShipSize.Small;
        AntiNitrineRadiant = false;
    }
}