using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Environments;

public class NitrineParticleFog : BaseEnvironment
{
    public NitrineParticleFog()
    {
        HasObstacle = false;
    }

    public override void AddObstacle(BaseObstacle obstacle, int obstacleNumber)
    {
        if (obstacle == null) throw new ArgumentNullException(nameof(obstacle));
        if (obstacle.GetType() == typeof(SpaceWhale))
        {
            FirstObstacle = obstacle;
            FirstObstacleNumber = obstacleNumber;
            HasObstacle = true;
        }
        else
        {
            throw new FormatException("Can't add Obstacle");
        }
    }

    public override bool IsEngineAllowed(BaseEngine engine)
    {
        if (engine == null) throw new ArgumentNullException(nameof(engine));
        return engine.GetType() == typeof(EngineRankE);
    }
}