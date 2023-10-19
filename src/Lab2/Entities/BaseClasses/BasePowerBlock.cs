namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BasePowerBlock
{
    public BasePowerBlock(int power)
    {
        Power = power;
    }

    public int Power { get; protected set; }
}