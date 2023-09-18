namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseEngine
{
    public bool IsRunning { get; private set; }
    public double FuelRate { get; private set; }
    public double Speed { get; private set; }
    public virtual string Status => $"{GetType().Name} {GetHashCode()}: {(IsRunning ? "Engine's ON" : "Engine's OFF")}";

    public virtual void Run()
    {
        IsRunning = true;
    }

    public virtual void StopWork()
    {
        IsRunning = false;
    }

    public virtual void SetSpeed()
    {
        Speed = 1;
    }
}