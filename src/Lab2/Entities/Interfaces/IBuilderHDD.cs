using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;

public interface IBuilderHDD
{
    public void MemoryCapacity(int memoryCapacity);
    public void RotationSpeed(int rotationSpeed);
    public void Power(int power);
    public BaseHDD BuildHDD();
}