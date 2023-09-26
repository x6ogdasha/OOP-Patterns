namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseEnvironment
{
   public BaseObstacle? FirstObstacle { get; protected set; }
   public BaseObstacle? SecondObstacle { get; protected set; }
   public int FirstObstacleNumber { get; protected set; }
   public int SecondObstacleNumber { get; protected set; }
   public bool HasFirstObstacle { get; protected set; }
   public bool HasSecondObstacle { get; protected set; }
   public virtual string Status => $"{GetType().Name} {GetHashCode()}:";

   public virtual bool IsEngineAllowed(BaseEngine engine)
   {
      return true;
   }

   public virtual void AddObstacle(BaseObstacle obstacle, int obstacleNumber)
   {
      FirstObstacle = obstacle;
      FirstObstacleNumber = obstacleNumber;
      SecondObstacleNumber = 0;
      HasFirstObstacle = true;
      HasSecondObstacle = false;
   }

   public virtual void AddObstacle(BaseObstacle firstObstacle, int firstObstacleNumber, BaseObstacle secondObstacle, int secondObstacleNumber)
   {
      FirstObstacle = firstObstacle;
      SecondObstacle = secondObstacle;
      FirstObstacleNumber = firstObstacleNumber;
      SecondObstacleNumber = secondObstacleNumber;
      HasFirstObstacle = true;
      HasSecondObstacle = true;
   }
}