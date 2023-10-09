using Itmo.ObjectOrientedProgramming.Lab1.Helpers.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseDeflector : Protection
{
    public bool PhotonDeflector { get; protected set; }
    public double RemainingDamage { get; protected set; }
    public bool KillCrew { get; protected set; }

    public void TurnOnPhotonDeflector()
    {
        PhotonDeflector = true;
    }

    public override void TakeDamage(BaseObstacle? obstacle, int numberOfObstacles)
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
            PhotonDeflector = false;
        }

        if (obstacle is AntiMatterFlare && PhotonDeflector == false)
        {
            IsActive = false;
            KillCrew = true;
        }
    }
}
