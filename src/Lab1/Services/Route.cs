using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Route
{
    private IList<Path> _route;
    private BaseShip _ship;
    private double _summaryFuel;
    private double? _summaryTime;
    private string _status;

    public Route(BaseShip ship, IList<Path> route)
    {
        _route = route;
        _ship = ship;
        _summaryFuel = 0;
        _summaryTime = 0;
        _status = "null";
    }

    public string IsRoutePassed()
    {
        foreach (Path path in _route)
        {
            path.IsPassed(_ship);
            if (path.Successful)
            {
                _summaryFuel += path.FuelOnPath;
                _summaryTime += path.TimeOnPath;
                _status = $"Successful! Summary fuel: {_summaryFuel}, time: {_summaryTime}";
            }
            else if (path.CrewIsDead)
            {
                _status = "Crew is dead";
                break;
            }
            else if (path.ShipIsBroken)
            {
                _status = "Ship is broken";
                break;
            }
            else if (path.ShipIsEscaped)
            {
                _status = "Ship is escaped";
                break;
            }
        }

        return _status;
    }
}