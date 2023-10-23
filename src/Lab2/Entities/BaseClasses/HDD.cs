using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class HDD : BaseComponent, IPrototype
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
}