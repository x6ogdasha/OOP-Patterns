using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class XMP : Prototype
{
    public XMP(string timing, int voltage, int frequency)
    {
        Timing = timing;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Timing { get; protected set; }
    public int Voltage { get; protected set; }
    public int Frequency { get; protected set; }
    public override Prototype Clone()
    {
        return new XMP(Timing, Voltage, Frequency);
    }

    public Prototype CloneWithNewTiming(string timing)
    {
        return new XMP(timing, Voltage, Frequency);
    }
}