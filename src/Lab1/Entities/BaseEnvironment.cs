using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseEnvironment
{
   public IEnumerable<BaseObstacle>? Obstacles { get; protected set; }
   public bool HasObstacle { get; protected set; }
   public virtual string Status => $"{GetType().Name} {GetHashCode()}: {(HasObstacle ? "Has obstacle" : "Has NOT obstacle")}";

   public virtual bool IsEngineAllowed(BaseEngine engine)
   {
      return true;
   }

   public virtual void AddObstacle(IEnumerable<BaseObstacle> obstacles)
   {
      Obstacles = obstacles;
   }
}