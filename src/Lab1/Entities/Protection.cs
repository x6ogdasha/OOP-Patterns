using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class Protection
{
    public double HealthPoints { get; protected set; }
    public bool IsActive { get; protected set; }

    public virtual void TakeDamage(BaseObstacle? obstacle, int numberOfObstacles)
    {
        if (obstacle != null)
        {
            HealthPoints -= obstacle.Damage * numberOfObstacles;
        }
        else
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        if (HealthPoints <= 0)
        {
            IsActive = false;
        }
    }
}