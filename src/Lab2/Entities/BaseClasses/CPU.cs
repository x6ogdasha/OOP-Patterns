using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class CPU : Prototype
{
    public CPU(string socketName, int coreNumber, int coreFrequency, bool? internalGPU, IReadOnlyList<string> supportedRamFrequencyList, int tdp, int power)
    {
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
    public override Prototype Clone()
    {
        return new CPU(SocketName, CoreNumber, CoreFrequency, InternalGPU, AllowedRAMFrequency, TDP, Power);
    }

    public Prototype CloneWithNewCores(int newFrequency, int newCoreNumber)
    {
        return new CPU(SocketName, newCoreNumber, newFrequency, InternalGPU, AllowedRAMFrequency, TDP, Power);
    }

    public Prototype CloneWithNewSocket(string newSocket)
    {
        return new CPU(newSocket, CoreNumber, CoreFrequency, InternalGPU, AllowedRAMFrequency, TDP, Power);
    }

    public Prototype CloneWithNewInternalGpu(bool newInternalGpu)
    {
        return new CPU(SocketName, CoreNumber, CoreFrequency, newInternalGpu, AllowedRAMFrequency, TDP, Power);
    }

    public Prototype CloneWithNewPowerTdp(int newPower, int newTdp)
    {
        return new CPU(SocketName, CoreNumber, CoreFrequency, InternalGPU, AllowedRAMFrequency, newTdp, newPower);
    }
}
