using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class Cpu : BaseComponent, IPrototype, IEquatable<Cpu>
{
    public Cpu(string name, string socketName, int coreNumber, int coreFrequency, bool internalGPU, IReadOnlyList<string> supportedRamFrequencyList, int tdp, int power)
    {
        Name = name;
        SocketName = socketName;
        CoreNumber = coreNumber;
        CoreFrequency = coreFrequency;
        InternalGPU = internalGPU;
        TDP = tdp;
        Power = power;
        AllowedRAMFrequency = supportedRamFrequencyList;
    }

    public Cpu()
    {
       AllowedRAMFrequency = new List<string>();
       SocketName = "null";
    }

    public int CoreFrequency { get; set; }
    public int CoreNumber { get; set; }
    public string SocketName { get; set; }
    public IReadOnlyList<string> AllowedRAMFrequency { get; set; }
    public bool InternalGPU { get; set; }
    public int TDP { get; set; }
    public int Power { get; set; }
    public IPrototype Clone()
    {
        return new Cpu(Name, SocketName, CoreNumber, CoreFrequency, InternalGPU, AllowedRAMFrequency, TDP, Power);
    }

    public IPrototype CloneWithNewCores(int newFrequency, int newCoreNumber, string newName)
    {
        return new Cpu(newName, SocketName, newCoreNumber, newFrequency, InternalGPU, AllowedRAMFrequency, TDP, Power);
    }

    public IPrototype CloneWithNewSocket(string newSocket, string newName)
    {
        return new Cpu(newName, newSocket, CoreNumber, CoreFrequency, InternalGPU, AllowedRAMFrequency, TDP, Power);
    }

    public IPrototype CloneWithNewInternalGpu(bool newInternalGpu, string newName)
    {
        return new Cpu(newName, SocketName, CoreNumber, CoreFrequency, newInternalGpu, AllowedRAMFrequency, TDP, Power);
    }

    public IPrototype CloneWithNewPowerTdp(int newPower, int newTdp, string newName)
    {
        return new Cpu(newName, SocketName, CoreNumber, CoreFrequency, InternalGPU, AllowedRAMFrequency, newTdp, newPower);
    }

    public bool Equals(Cpu? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return CoreFrequency == other.CoreFrequency && CoreNumber == other.CoreNumber && SocketName == other.SocketName && AllowedRAMFrequency.Equals(other.AllowedRAMFrequency) && InternalGPU == other.InternalGPU && TDP == other.TDP && Power == other.Power;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not Cpu) return false;
        return Equals((Cpu)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CoreFrequency, CoreNumber, SocketName, AllowedRAMFrequency, InternalGPU, TDP, Power);
    }
}
