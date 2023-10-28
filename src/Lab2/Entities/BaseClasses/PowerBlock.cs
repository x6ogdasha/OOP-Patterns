using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class PowerBlock : BaseComponent, IPrototype, IEquatable<PowerBlock>
{
    public PowerBlock(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public PowerBlock()
    {
        Name = string.Empty;
    }

    public int Power { get; protected set; }
    public IPrototype Clone()
    {
        return new PowerBlock(Name, Power);
    }

    public bool Equals(PowerBlock? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Power == other.Power;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not PowerBlock) return false;
        return Equals((PowerBlock)obj);
    }

    public override int GetHashCode()
    {
        return Power;
    }
}