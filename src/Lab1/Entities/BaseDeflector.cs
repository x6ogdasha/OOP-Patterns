using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseDeflector : Protection
{
    public bool PhotonDeflector { get; protected set; }
    public override void TakeDamage(BaseObstacle? obstacle, int numberOfObstacles)
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
            PhotonDeflector = false;
        }

        if (obstacle.GetType() == typeof(AntiMatterFlare) && PhotonDeflector == false)
        {
            IsActive = false;
        }
    }
}
