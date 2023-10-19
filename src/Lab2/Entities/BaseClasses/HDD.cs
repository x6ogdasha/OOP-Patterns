using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class HDD : Prototype
{
    public HDD(int memoryCapacity, int rotationSpeed, int power)
    {
        MemoryCapacity = memoryCapacity;
        RotationSpeed = rotationSpeed;
        Power = power;
    }

    public int MemoryCapacity { get; protected set; }
    public int RotationSpeed { get; protected set; }
    public int Power { get; protected set; }
    public override Prototype Clone()
    {
        return new HDD(MemoryCapacity, RotationSpeed, Power);
    }

    public Prototype CloneWithNewCapacity(int newCapacity)
    {
        return new HDD(newCapacity, RotationSpeed, Power);
    }

    public Prototype CloneWithNewRotationSpeed(int newSpeed)
    {
        return new HDD(MemoryCapacity, newSpeed, Power);
    }

    public Prototype CloneWithNewPower(int newPower)
    {
        return new HDD(MemoryCapacity, RotationSpeed, newPower);
    }
}