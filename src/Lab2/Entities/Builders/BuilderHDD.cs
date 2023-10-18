using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;

public class BuilderHDD : IBuilderHDD
{
    private int _memoryCapacity;
    private int _rotationSpeed;
    private int _power;

    public BuilderHDD(BaseHDD hdd)
    {
        if (hdd == null) throw new ArgumentNullException(nameof(hdd));
        _memoryCapacity = hdd.MemoryCapacity;
        _rotationSpeed = hdd.RotationSpeed;
        _power = hdd.Power;
    }

    public void MemoryCapacity(int memoryCapacity)
    {
        _memoryCapacity = memoryCapacity;
    }

    public void RotationSpeed(int rotationSpeed)
    {
        _rotationSpeed = rotationSpeed;
    }

    public void Power(int power)
    {
        _power = power;
    }

    public BaseHDD BuildHDD()
    {
        return new BaseHDD(_memoryCapacity, _rotationSpeed, _power);
    }
}