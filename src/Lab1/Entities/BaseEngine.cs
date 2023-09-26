namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseEngine
{
    protected const double GravitationalMatterCost = 97.4;
    protected const double ActivePlasmaCost = 65.7;
    public bool IsRunning { get; protected set; }
    public double FuelRate { get; protected set; }
    public double FuelСost { get; protected set; }
    public string Status => $"{GetType()} {GetHashCode()}: {(IsRunning ? "Working. " : "Not working. ")} ";

    public virtual void Run()
    {
        IsRunning = true;
    }

    public virtual double Move(double distance)
    {
        return 0;
    }
}