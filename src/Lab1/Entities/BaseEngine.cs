using System.Data;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseEngine
{
    public bool IsRunning { get; protected set; }
    public double FuelRate { get; protected set; }
    public FuelType Fuel { get; protected set; }
    public double Capacity { get; protected set; }
    public string Status => $"{GetType()} {GetHashCode()}: {(IsRunning ? "Working. " : "Not working. ")} Fuel: {Fuel}";

    public virtual void Run()
    {
        IsRunning = true;
    }

    public virtual double Move(double distance)
    {
        Capacity -= FuelRate * distance;
        if (Capacity < 0) throw new EvaluateException("No Fuel to complete distance");
        return Capacity;
    }
}