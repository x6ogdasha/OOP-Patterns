namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseShell : Protection
{
    public void TakeRemainDamage(double damage)
    {
        HealthPoints -= damage;
        if (HealthPoints <= 0)
        {
            IsActive = false;
        }
    }
}