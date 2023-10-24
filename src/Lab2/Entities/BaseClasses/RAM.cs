using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class RAM : BaseComponent, IPrototype
{
    public RAM(string name, int memorySize, int frequency, int voltage, RAMFormFactor formFactor, int standardOfDdr, int power, XMP? profileXmp)
    {
        Name = name;
        MemorySize = memorySize;
        Frequency = frequency;
        Voltage = voltage;
        FormFactor = formFactor;
        StandardOfDDR = standardOfDdr;
        Power = power;
        ProfileXMP = profileXmp;
    }

    public RAM()
    {
        Name = "null";
    }

    public int MemorySize { get; protected set; }
    public int Frequency { get; protected set; }
    public int Voltage { get; protected set; }
    public RAMFormFactor FormFactor { get; protected set; }
    public int StandardOfDDR { get; protected set; }
    public int Power { get; protected set; }
    public XMP? ProfileXMP { get; protected set; }
    public IPrototype Clone()
    {
        return new RAM(Name, MemorySize, Frequency, Voltage, FormFactor, StandardOfDDR, Power, ProfileXMP);
    }

    public IPrototype CloneWithNewMemorySize(int newMemorySize, string newName)
    {
        return new RAM(newName, newMemorySize, Frequency, Voltage, FormFactor, StandardOfDDR, Power, ProfileXMP);
    }

    public IPrototype CloneWithNewFrequency(int newFrequency, string newName)
    {
        return new RAM(newName, MemorySize, newFrequency, Voltage, FormFactor, StandardOfDDR, Power, ProfileXMP);
    }

    public IPrototype CloneWithNewStandardOfDdr(int newStandard, string newName)
    {
        return new RAM(newName, MemorySize, Frequency, Voltage, FormFactor, newStandard, Power, ProfileXMP);
    }

    public IPrototype CloneWithNewProfileXmp(XMP? newXmp, string newName)
    {
        return new RAM(newName, MemorySize, Frequency, Voltage, FormFactor, StandardOfDDR, Power, newXmp);
    }
}