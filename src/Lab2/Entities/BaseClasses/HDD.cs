using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class HDD : BaseComponent, IPrototype, IEquatable<HDD>
{
    public HDD(string name, int memoryCapacity, int rotationSpeed, int power)
    {
        Name = name;
        MemoryCapacity = memoryCapacity;
        RotationSpeed = rotationSpeed;
        Power = power;
    }

    public int MemoryCapacity { get; protected set; }
    public int RotationSpeed { get; protected set; }
    public int Power { get; protected set; }
    public IPrototype Clone()
    {
        return new HDD(Name, MemoryCapacity, RotationSpeed, Power);
    }

    public IPrototype CloneWithNewCapacity(int newCapacity, string newName)
    {
        return new HDD(newName, newCapacity, RotationSpeed, Power);
    }

    public IPrototype CloneWithNewRotationSpeed(int newSpeed, string newName)
    {
        return new HDD(newName, MemoryCapacity, newSpeed, Power);
    }

    public IPrototype CloneWithNewPower(int newPower, string newName)
    {
        return new HDD(newName, MemoryCapacity, RotationSpeed, newPower);
    }

    public bool Equals(HDD? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return MemoryCapacity == other.MemoryCapacity && RotationSpeed == other.RotationSpeed && Power == other.Power;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not HDD) return false;
        return Equals((HDD)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(MemoryCapacity, RotationSpeed, Power);
    }
}