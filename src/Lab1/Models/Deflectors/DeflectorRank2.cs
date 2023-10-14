using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;

public class DeflectorRank2 : BaseDeflector
{
    private const double MaxDamageDifference = 10;
    private const double HealthPointsValue = 50;
    public DeflectorRank2()
    {
        HealthPoints = HealthPointsValue;
        IsActive = true;
    }

    public override void TakeDamage(BaseObstacle? obstacle, int numberOfObstacles)
    {
        if (obstacle is not null)
            HealthPoints -= obstacle.Damage * numberOfObstacles;
        else
            throw new ObstacleNullException();

        if (HealthPoints <= 0)
        {
            IsActive = false;
            PhotonDeflector = false;
            if (Math.Abs(HealthPoints) > MaxDamageDifference)
                RemainingDamage = Math.Abs(HealthPoints);
        }

        if (obstacle is AntiMatterFlare && !PhotonDeflector)
        {
            IsActive = false;
            KillCrew = true;
        }
    }
    }