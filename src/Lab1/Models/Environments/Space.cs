using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Environments;

public class Space : BaseEnvironment
{
    private IEnumerable<BaseObstacle>? _obstacles;
    public Space(IEnumerable<BaseObstacle> obstacles)
   {
           _obstacles = obstacles.Where(p =>
               p.GetType() == typeof(Meteorit) ||
               p.GetType() == typeof(Asteroid));
   }

    public Space()
    {
    }
}