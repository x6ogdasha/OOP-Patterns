namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BaseHDD
{
    public BaseHDD(int memoryCapacity, int rotationSpeed, int power)
    {
        MemoryCapacity = memoryCapacity;
        RotationSpeed = rotationSpeed;
        Power = power;
    }

    public int MemoryCapacity { get; protected set; }
    public int RotationSpeed { get; protected set; }
    public int Power { get; protected set; }
}