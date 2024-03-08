using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class SpaceWhale : BaseObstacle
{
    private const double DamageValue = 200;
    public SpaceWhale()
    {
        Damage = DamageValue;
    }
}