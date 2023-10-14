using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class Asteroid : BaseObstacle
{
    private const double DamageValue = 5;
    public Asteroid()
    {
        Damage = DamageValue;
    }
}