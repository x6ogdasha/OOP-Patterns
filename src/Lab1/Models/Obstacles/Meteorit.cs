using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class Meteorit : BaseObstacle
{
    private const double DamageValue = 20;
    public Meteorit()
    {
        Damage = DamageValue;
    }
}