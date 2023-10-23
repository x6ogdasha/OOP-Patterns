using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class CPU : BaseComponent, IPrototype
{
    public CPU(string name, string socketName, int coreNumber, int coreFrequency, bool? internalGPU, IReadOnlyList<string> supportedRamFrequencyList, int tdp, int power)
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

    public CPU()
    {
       AllowedRAMFrequency = new List<string>();
       SocketName = "null";
    }

    public int CoreFrequency { get; set; }
    public int CoreNumber { get; set; }
    public string SocketName { get; set; }
    public IReadOnlyList<string> AllowedRAMFrequency { get; set; }
    public bool? InternalGPU { get; set; }
    public int TDP { get; set; }
    public int Power { get; set; }
    public IPrototype Clone()
    {
        return new CPU(Name, SocketName, CoreNumber, CoreFrequency, InternalGPU, AllowedRAMFrequency, TDP, Power);
    }

    public IPrototype CloneWithNewCores(int newFrequency, int newCoreNumber, string newName)
    {
        return new CPU(newName, SocketName, newCoreNumber, newFrequency, InternalGPU, AllowedRAMFrequency, TDP, Power);
    }

    public IPrototype CloneWithNewSocket(string newSocket, string newName)
    {
        return new CPU(newName, newSocket, CoreNumber, CoreFrequency, InternalGPU, AllowedRAMFrequency, TDP, Power);
    }

    public IPrototype CloneWithNewInternalGpu(bool newInternalGpu, string newName)
    {
        return new CPU(newName, SocketName, CoreNumber, CoreFrequency, newInternalGpu, AllowedRAMFrequency, TDP, Power);
    }

    public IPrototype CloneWithNewPowerTdp(int newPower, int newTdp, string newName)
    {
        return new CPU(newName, SocketName, CoreNumber, CoreFrequency, InternalGPU, AllowedRAMFrequency, newTdp, newPower);
    }
}
