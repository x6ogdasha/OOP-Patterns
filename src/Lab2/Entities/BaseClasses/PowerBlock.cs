using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class PowerBlock : Prototype
{
    public PowerBlock(int power)
    {
        Power = power;
    }

    public int Power { get; protected set; }
    public override Prototype Clone()
    {
        return new PowerBlock(Power);
    }
}