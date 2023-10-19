using Itmo.ObjectOrientedProgramming.Lab2.Common;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BaseRAM
{
    public BaseRAM(int memorySize, int frequency, int voltage, RAMFormFactor formFactor, int standardOfDdr, int power, BaseXMP? profileXmp)
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
    public BaseXMP? ProfileXMP { get; protected set; }
}