namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseEnvironment
{
   public bool HasObstacle { get; private set; }
   public virtual string Status => $"{GetType().Name} {GetHashCode()}: {(HasObstacle ? "Has obstacle" : "Has NOT obstacle")}";
   public abstract bool IsEngineAllowed();
}