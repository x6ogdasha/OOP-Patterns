using Itmo.ObjectOrientedProgramming.Lab2.Common;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BaseSSD
{
    public BaseSSD(MemoryConnectionType connectionType, int memoryCapacity, int speed, int power)
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
}