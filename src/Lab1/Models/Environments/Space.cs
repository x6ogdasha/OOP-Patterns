using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Environments;

public class Space : BaseEnvironment
{
    public Space()
    {
        HasObstacle = false;
    }

    public override void AddObstacle(IEnumerable<BaseObstacle> obstacles)
    {
        Obstacles = obstacles.Where(p =>
            p.GetType() == typeof(Meteorit) ||
            p.GetType() == typeof(Asteroid));
        HasObstacle = true;
    }
}