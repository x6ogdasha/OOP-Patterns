using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Environments;

public class Space : BaseEnvironment
{
    public Space()
    {
        HasObstacle = false;
    }

    public override void AddObstacle(BaseObstacle obstacle, int obstacleNumber)
    {
        if (obstacle == null) throw new ArgumentNullException(nameof(obstacle));
        if (obstacle.GetType() == typeof(Asteroid) || obstacle.GetType() == typeof(Meteorit))
        {
            FirstObstacle = obstacle;
            FirstObstacleNumber = obstacleNumber;
            HasObstacle = true;
        }
    }

    public override void AddObstacle(BaseObstacle firstObstacle, int firstObstacleNumber, BaseObstacle secondObstacle, int secondObstacleNumber)
    {
        if (firstObstacle == null) throw new ArgumentNullException(nameof(firstObstacle));
        if (secondObstacle == null) throw new ArgumentNullException(nameof(secondObstacle));
        if ((firstObstacle.GetType() == typeof(Asteroid) && secondObstacleNumber.GetType() == typeof(Meteorit)) ||
            (firstObstacle.GetType() == typeof(Meteorit) && secondObstacle.GetType() == typeof(Asteroid)))
        {
            FirstObstacle = firstObstacle;
            SecondObstacle = secondObstacle;
            FirstObstacleNumber = firstObstacleNumber;
            SecondObstacleNumber = secondObstacleNumber;
            HasObstacle = true;
        }
    }
}