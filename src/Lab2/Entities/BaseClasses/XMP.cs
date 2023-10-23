using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class XMP : BaseComponent, IPrototype
{
    public XMP(string name, string timing, int voltage, int frequency)
    {
        Name = name;
        Timing = timing;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Timing { get; protected set; }
    public int Voltage { get; protected set; }
    public int Frequency { get; protected set; }
    public IPrototype Clone()
    {
        return new XMP(Name, Timing, Voltage, Frequency);
    }

    public IPrototype CloneWithNewTiming(string timing, string newName)
    {
        return new XMP(newName, timing, Voltage, Frequency);
    }
}