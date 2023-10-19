namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BaseXMP
{
    public BaseXMP(string timing, int voltage, int frequency)
    {
        Timing = timing;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Timing { get; protected set; }
    public int Voltage { get; protected set; }
    public int Frequency { get; protected set; }
}