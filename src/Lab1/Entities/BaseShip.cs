using Itmo.ObjectOrientedProgramming.Lab1.Helpers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseShip
{
    public abstract BaseEngine Engine { get; set; }
    public abstract BaseDeflector? Deflector { get; set; }
    public ShipSize Size { get; private set; }
    public abstract BaseShell Shell { get; set; }
}