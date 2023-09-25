using System;
using System.Collections.Generic;
using System.Linq;
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

    public override void AddObstacle(IEnumerable<BaseObstacle> obstacles)
    {
        Obstacles = obstacles.Where(p =>
            p.GetType() == typeof(SpaceWhale));
        HasObstacle = true;
    }

    public override bool IsEngineAllowed(BaseEngine engine)
    {
        if (engine == null) throw new ArgumentNullException(nameof(engine));
        return engine.GetType() == typeof(EngineRankE);
    }
}