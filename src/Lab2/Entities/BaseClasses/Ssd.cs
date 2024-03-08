using System;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class Ssd : BaseComponent, IPrototype, IEquatable<Ssd>
{
    public Ssd(string name, MemoryConnectionType connectionType, int memoryCapacity, int speed, int power)
    {
        Name = name;
        ConnectionType = connectionType;
        MemoryCapacity = memoryCapacity;
        Speed = speed;
        Power = power;
    }

    public MemoryConnectionType ConnectionType { get; protected set; }
    public int MemoryCapacity { get; protected set; }
    public int Speed { get; protected set; }
    public int Power { get; protected set; }
    public IPrototype Clone()
    {
        return new Ssd(Name, ConnectionType, MemoryCapacity, Speed, Power);
    }

    public IPrototype CloneWithNewConnectionType(MemoryConnectionType newType, string newName)
    {
        return new Ssd(newName, newType, MemoryCapacity, Speed, Power);
    }

    public IPrototype CloneWithNewCapacity(int newCapacity, string newName)
    {
        return new Ssd(newName, ConnectionType, newCapacity, Speed, Power);
    }

    public IPrototype CloneWithNewSpeed(int newSpeed, string newName)
    {
        return new Ssd(newName, ConnectionType, MemoryCapacity, newSpeed, Power);
    }

    public bool Equals(Ssd? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return ConnectionType == other.ConnectionType && MemoryCapacity == other.MemoryCapacity && Speed == other.Speed && Power == other.Power;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not Ssd) return false;
        return Equals((Ssd)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)ConnectionType, MemoryCapacity, Speed, Power);
    }
}