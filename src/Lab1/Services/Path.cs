using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Path
{
   private BaseEnvironment _environment;
   private double _distance;
   public Path(BaseEnvironment environment, double distance)
   {
      _environment = environment;
      _distance = distance;
   }

   public bool Successful { get; protected set; }
   public bool CrewIsDead { get; protected set; }
   public bool ShipIsBroken { get; protected set; }
   public bool ShipIsEscaped { get; protected set; }
   public double FuelOnPath { get; protected set; }
   public double? TimeOnPath { get; protected set; }

   public bool IsPassed(BaseShip ship)
   {
      if (ship == null) throw new ArgumentNullException(nameof(ship));
      BaseEngine? currentEngine = null;
      if (_environment.IsEngineAllowed(ship.MainEngine))
      {
         currentEngine = ship.MainEngine;
      }
      else if (_environment.IsEngineAllowed(ship.AdditionalEngine))
      {
         currentEngine = ship.AdditionalEngine;
      }

      if (currentEngine != null)
      {
         if (_environment.FirstObstacle != null)
         {
            ship.TakeDamage(_environment.FirstObstacle, _environment.FirstObstacleNumber);
            if (ship.IsShipIntact == false)
            {
               ShipIsBroken = true;
               return false;
            }

            if (ship.IsCrewAlive == false)
            {
               CrewIsDead = true;
               return false;
            }
         }

         if (_environment.SecondObstacle != null)
         {
            ship.TakeDamage(_environment.SecondObstacle, _environment.SecondObstacleNumber);
            if (ship.IsShipIntact == false)
            {
               ShipIsBroken = true;
               return false;
            }

            if (ship.IsCrewAlive == false)
            {
               CrewIsDead = true;
               return false;
            }
         }

         TimeOnPath = ship.TimeToMove(currentEngine, _distance);
         if (TimeOnPath != null)
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

      return false;
   }
}