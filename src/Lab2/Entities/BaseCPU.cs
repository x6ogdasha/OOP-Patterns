using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class BaseCPU
{
    private readonly List<string> _supportedRAMFrequencyList;

    public BaseCPU()
    {
        _supportedRAMFrequencyList = new List<string>();
    }

    public int CoreFrequency { get; protected set; }
    public int CoreNumber { get; protected set; }
    public string? Socket { get; protected set; }
    public bool? InternalVideoCore { get; protected set; }
    public IReadOnlyList<string> SupportedRAMFrequency => _supportedRAMFrequencyList;
    public int TDP { get; protected set; }
    public int Power { get; protected set; }
}
