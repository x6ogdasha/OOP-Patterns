using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class SSD : Prototype
{
    public SSD(MemoryConnectionType connectionType, int memoryCapacity, int speed, int power)
    {
        ConnectionType = connectionType;
        MemoryCapacity = memoryCapacity;
        Speed = speed;
        Power = power;
    }

    public MemoryConnectionType ConnectionType { get; protected set; }
    public int MemoryCapacity { get; protected set; }
    public int Speed { get; protected set; }
    public int Power { get; protected set; }
    public override Prototype Clone()
    {
        return new SSD(ConnectionType, MemoryCapacity, Speed, Power);
    }

    public Prototype CloneWithNewConnectionType(MemoryConnectionType newType)
    {
        return new SSD(newType, MemoryCapacity, Speed, Power);
    }

    public Prototype CloneWithNewCapacity(int newCapacity)
    {
        return new SSD(ConnectionType, newCapacity, Speed, Power);
    }

    public Prototype CloneWithNewSpeed(int newSpeed)
    {
        return new SSD(ConnectionType, MemoryCapacity, newSpeed, Power);
    }
}