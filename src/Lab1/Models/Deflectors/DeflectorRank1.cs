using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;

public class DeflectorRank1 : BaseDeflector
{
    private const double MaxDamageDifference = 0;
    public DeflectorRank1()
    {
        HealthPoints = 10;
        IsActive = true;
    }

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
            if (Math.Abs(HealthPoints) > MaxDamageDifference)
            {
                RemainingDamage = Math.Abs(HealthPoints);
            }
        }

        if (obstacle.GetType() == typeof(AntiMatterFlare) && PhotonDeflector == false)
        {
            IsActive = false;
            KillCrew = true;
        }
    }
}