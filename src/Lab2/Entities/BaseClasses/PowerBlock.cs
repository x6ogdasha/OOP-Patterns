using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class PowerBlock : BaseComponent, IPrototype
{
    public PowerBlock(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public int Power { get; protected set; }
    public IPrototype Clone()
    {
        return new PowerBlock(Name, Power);
    }
}