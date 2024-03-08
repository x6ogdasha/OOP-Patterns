using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class AntiMatterFlare : BaseObstacle
{
    private const double DamageValue = 0;
    public AntiMatterFlare()
    {
        Damage = DamageValue;
    }
}