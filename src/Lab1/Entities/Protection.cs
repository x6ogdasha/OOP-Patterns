using Itmo.ObjectOrientedProgramming.Lab1.Helpers.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class Protection
{
    public double HealthPoints { get; protected set; }
    public bool IsActive { get; protected set; }

    public virtual void TakeDamage(BaseObstacle? obstacle, int numberOfObstacles)
    {
        if (obstacle is not null)
        {
            HealthPoints -= obstacle.Damage * numberOfObstacles;
        }
        else
        {
            throw new ObstacleNullException();
        }

        if (HealthPoints <= 0)
        {
            IsActive = false;
        }
    }
}