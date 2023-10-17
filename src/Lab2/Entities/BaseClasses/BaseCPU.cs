using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BaseCPU
{
    public BaseCPU(string socketName, int coreNumber, int coreFrequency, bool? internalGPU, IReadOnlyList<string> supportedRamFrequencyList, int tdp, int power)
    {
        SocketName = socketName;
        CoreNumber = coreNumber;
        CoreFrequency = coreFrequency;
        InternalGPU = internalGPU;
        TDP = tdp;
        Power = power;
        AllowedRAMFrequency = supportedRamFrequencyList;
    }

    public BaseCPU()
    {
       AllowedRAMFrequency = new List<string>();
    }

    public int CoreFrequency { get; set; }
    public int CoreNumber { get; set; }
    public string? SocketName { get; set; }
    public IReadOnlyList<string> AllowedRAMFrequency { get; set; }
    public bool? InternalGPU { get; set; }
    public int TDP { get; set; }
    public int Power { get; set; }
}
