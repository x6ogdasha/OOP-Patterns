using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Path
{
   private readonly BaseEnvironment _environment;
   private readonly double _distance;
   public Path(BaseEnvironment environment, double distance)
   {
      _environment = environment;
      _distance = distance;
      ShipIsEscaped = false;
   }

   public bool Successful { get; private set; }
   public bool CrewIsDead { get; private set; }
   public bool ShipIsBroken { get; private set; }
   public bool ShipIsEscaped { get; private set; }
   public bool IsShipDenied { get; private set; }
   public double FuelOnPath { get; private set; }
   public double? TimeOnPath { get; private set; }

   public bool IsPassed(BaseShip ship)
   {
      if (ship is null) throw new ShipNullException();
      BaseEngine? allowedEngine = GetAllowedEngine(ship);
      if (allowedEngine is not null)
      {
         if (!SuccessfulHandleObstacle(ship, _environment.FirstObstacle, _environment.FirstObstacleNumber) || !SuccessfulHandleObstacle(ship, _environment.SecondObstacle, _environment.SecondObstacleNumber))
            return false;

         TimeOnPath = ship.TimeToMove(allowedEngine, _distance);

         if (!SuccessfulHandlePath(TimeOnPath, allowedEngine))
            return false;
      }
      else
      {
         IsShipDenied = true;
         return false;
      }

      return false;
   }

   private BaseEngine? GetAllowedEngine(BaseShip ship)
   {
      BaseEngine? allowedEngine = null;
      if (_environment.IsEngineAllowed(ship.MainEngine))
         allowedEngine = ship.MainEngine;
      else if (_environment.IsEngineAllowed(ship.AdditionalEngine))
         allowedEngine = ship.AdditionalEngine;

      return allowedEngine;
   }

   private bool SuccessfulHandleObstacle(BaseShip ship, BaseObstacle? obstacle, int obstacleNumber)
   {
      if (obstacle is not null)
      {
         ship.TakeDamage(obstacle, obstacleNumber);
         if (ship.IsBroken)
         {
            ShipIsBroken = true;
            return false;
         }

         if (ship.IsCrewDead)
         {
            CrewIsDead = true;
            return false;
         }
      }

      return true;
   }

   private bool SuccessfulHandlePath(double? timeOnPath, BaseEngine currentEngine)
   {
      if (timeOnPath is not null)
      {
         Successful = true;
         FuelOnPath = currentEngine.FuelRate * _distance;
         return true;
      }
      else
      {
         Successful = false;
         ShipIsEscaped = true;
         return false;
      }
   }
}