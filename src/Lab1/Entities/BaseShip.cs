using Itmo.ObjectOrientedProgramming.Lab1.Helpers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseShip
{
    public BaseEngine? MainEngine { get; protected set; }
    public BaseEngine? AdditionalEngine { get; protected set; }
    public BaseDeflector? Deflector { get; protected set; }
    public ShipSize Size { get; protected set; }
    public BaseShell? Shell { get; protected set; }
    public bool AntiNitrineRadiant { get; protected set; }
}