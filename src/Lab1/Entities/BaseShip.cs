using System;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Shells;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class BaseShip
{
    public BaseEngine MainEngine { get; protected set; } = new EngineRankC();
    public BaseEngine AdditionalEngine { get; protected set; } = new EngineRankC();
    public BaseDeflector? Deflector { get; protected set; }
    public ShipSize Size { get; protected set; }
    public BaseShell Shell { get; protected set; } = new ShellRank1();
    public bool? IsShipIntact { get; protected set; }
    public bool? IsCrewAlive { get; protected set; }
    public bool? AntiNitrineRadiant { get; protected set; }
    public string Status => $"Deflector HP: {Deflector?.HealthPoints}, Shell HP: {Shell.HealthPoints}";

    public void TakeDamage(BaseObstacle obstacle, int numberOfObstacles)
    {
        if (obstacle == null) throw new ArgumentNullException(nameof(obstacle));
        if (AntiNitrineRadiant == true && obstacle.GetType() == typeof(SpaceWhale))
        {
            return;
        }

        if (Deflector?.IsActive == true)
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

        if (Shell.IsActive == false)
        {
            IsShipIntact = false;
        }

        if (Deflector?.KillCrew == true)
        {
            IsCrewAlive = false;
        }
    }

    public virtual double? TimeToMove(BaseEngine engine, double distance)
    {
        if (engine == null) throw new ArgumentNullException(nameof(engine));
        return engine.Move(distance);
    }
}