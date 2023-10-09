using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Environments;

public class Space : BaseEnvironment
{
    public Space()
    {
        HasFirstObstacle = false;
        HasSecondObstacle = false;
    }

    public override void AddObstacle(BaseObstacle obstacle, int obstacleNumber)
    {
        if (obstacle is null) throw new ObstacleNullException();
        if (obstacle is Asteroid || obstacle is Meteorit)
        {
            FirstObstacle = obstacle;
            FirstObstacleNumber = obstacleNumber;
            HasFirstObstacle = true;
            HasSecondObstacle = false;
        }
    }

    public override void AddObstacle(BaseObstacle firstObstacle, int firstObstacleNumber, BaseObstacle secondObstacle, int secondObstacleNumber)
    {
        if (firstObstacle is null) throw new ObstacleNullException();
        if (secondObstacle is null) throw new ObstacleNullException();
        if ((firstObstacle is Asteroid && secondObstacle is Meteorit) ||
            (firstObstacle is Meteorit && secondObstacle is Asteroid))
        {
            FirstObstacle = firstObstacle;
            SecondObstacle = secondObstacle;
            FirstObstacleNumber = firstObstacleNumber;
            SecondObstacleNumber = secondObstacleNumber;
            HasFirstObstacle = true;
            HasSecondObstacle = true;
        }
    }

    public override bool IsEngineAllowed(BaseEngine engine)
    {
        if (engine is null) throw new EngineNullException();
        return engine is EngineRankE || engine is EngineRankC;
    }
}