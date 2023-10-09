using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Environments;

public class HighDensityFog : BaseEnvironment
{
    public HighDensityFog()
    {
        HasFirstObstacle = false;
        HasSecondObstacle = false;
    }

    public override void AddObstacle(BaseObstacle obstacle, int obstacleNumber)
    {
        if (obstacle is null) throw new ObstacleNullException();
        if (obstacle is AntiMatterFlare)
        {
            FirstObstacle = obstacle;
            FirstObstacleNumber = obstacleNumber;
            SecondObstacleNumber = 0;
            HasFirstObstacle = true;
            HasSecondObstacle = false;
        }
        else
        {
            throw new ObstacleWrongTypeException();
        }
    }

    public override bool IsEngineAllowed(BaseEngine engine)
    {
        if (engine is null) throw new EngineNullException();
        return engine is EngineAlpha || engine is EngineGamma || engine is EngineOmega;
    }
}