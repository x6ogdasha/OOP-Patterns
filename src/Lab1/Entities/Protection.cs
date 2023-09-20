namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class Protection
{
    public double HealthPoints { get; protected set; }
    public void GetDamage(BaseObstacle? obstacle)
    {
        if (obstacle != null)
        {
            HealthPoints -= obstacle.Damage;
        }
    }
}