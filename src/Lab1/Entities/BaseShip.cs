using Itmo.ObjectOrientedProgramming.Lab1.Helpers;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Shells;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseShip
{
    public BaseEngine MainEngine { get; protected set; } = new EngineRankC();
    public BaseEngine AdditionalEngine { get; protected set; } = new EngineRankC();
    public BaseDeflector Deflector { get; protected set; } = new DeflectorRank1();
    public ShipSize Size { get; protected set; }
    public BaseShell Shell { get; protected set; } = new ShellRank1();
    public bool IsBroken { get; protected set; }
    public bool IsCrewDead { get; protected set; }
    public bool AntiNitrineRadiant { get; protected set; }
    public string Status => $"Deflector HP: {Deflector.HealthPoints}, Shell HP: {Shell.HealthPoints}";

    public void TakeDamage(BaseObstacle obstacle, int numberOfObstacles)
    {
        if (obstacle is null) throw new ObstacleNullException();
        if (AntiNitrineRadiant && obstacle is SpaceWhale) return;

        if (Deflector.IsActive)
        {
            Deflector.TakeDamage(obstacle, numberOfObstacles);
            if (Deflector.RemainingDamage != 0)
            {
                Shell.TakeRemainDamage(Deflector.RemainingDamage);
            }
        }
        else
        {
            Shell.TakeDamage(obstacle, numberOfObstacles);
        }

        if (!Shell.IsActive)
            IsBroken = true;

        if (Deflector.KillCrew)
            IsCrewDead = true;
    }

    public virtual double? TimeToMove(BaseEngine engine, double distance)
    {
        if (engine is null) throw new EngineNullException();
        return engine.Move(distance);
    }
}