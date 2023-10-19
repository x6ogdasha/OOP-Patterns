using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class RAM : Prototype
{
    public RAM(int memorySize, int frequency, int voltage, RAMFormFactor formFactor, int standardOfDdr, int power, XMP? profileXmp)
    {
        MemorySize = memorySize;
        Frequency = frequency;
        Voltage = voltage;
        FormFactor = formFactor;
        StandardOfDDR = standardOfDdr;
        Power = power;
        ProfileXMP = profileXmp;
    }

    public int MemorySize { get; protected set; }
    public int Frequency { get; protected set; }
    public int Voltage { get; protected set; }
    public RAMFormFactor FormFactor { get; protected set; }
    public int StandardOfDDR { get; protected set; }
    public int Power { get; protected set; }
    public XMP? ProfileXMP { get; protected set; }
    public override Prototype Clone()
    {
        return new RAM(MemorySize, Frequency, Voltage, FormFactor, StandardOfDDR, Power, ProfileXMP);
    }

    public Prototype CloneWithNewMemorySize(int newMemorySize)
    {
        return new RAM(newMemorySize, Frequency, Voltage, FormFactor, StandardOfDDR, Power, ProfileXMP);
    }

    public Prototype CloneWithNewFrequency(int newFrequency)
    {
        return new RAM(MemorySize, newFrequency, Voltage, FormFactor, StandardOfDDR, Power, ProfileXMP);
    }

    public Prototype CloneWithNewStandardOfDdr(int newStandard)
    {
        return new RAM(MemorySize, Frequency, Voltage, FormFactor, newStandard, Power, ProfileXMP);
    }

    public Prototype CloneWithNewProfileXmp(XMP? newXmp)
    {
        return new RAM(MemorySize, Frequency, Voltage, FormFactor, StandardOfDDR, Power, newXmp);
    }
}