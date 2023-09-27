using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Route
{
    private IList<Path> _route;
    private BaseShip _firstShip;
    private BaseShip? _secondShip;
    private double _firstSummaryFuel;
    private double? _firstSummaryTime;
    private double _secondSummaryFuel;
    private string _firstStatus;
    private string _secondStatus;

    public Route(BaseShip ship, IList<Path> route)
    {
        _route = route;
        _firstShip = ship;
        _firstSummaryFuel = 0;
        _firstSummaryTime = 0;
        _firstStatus = "null";
        _secondStatus = "null";
    }

    public Route(BaseShip firstShip, BaseShip secondShip, IList<Path> route)
    {
        _route = route;
        _firstShip = firstShip;
        _secondShip = secondShip;
        _firstSummaryFuel = 0;
        _secondSummaryFuel = 0;
        _firstSummaryTime = 0;
        _firstStatus = "null";
        _secondStatus = "null";
    }

    public string IsRoutePassed()
    {
        foreach (Path path in _route)
        {
            path.IsPassed(_firstShip);
            if (path.Successful)
            {
                _firstSummaryFuel += path.FuelOnPath;
                _firstSummaryTime += path.TimeOnPath;
                _firstStatus = $"Successful! Summary fuel: {_firstSummaryFuel}, time: {_firstSummaryTime}";
            }
            else if (path.CrewIsDead)
            {
                _firstStatus = "Fail! Crew is dead";
                break;
            }
            else if (path.ShipIsBroken)
            {
                _firstStatus = "Fail! Ship is broken";
                break;
            }
            else if (path.ShipIsEscaped)
            {
                _firstStatus = "Fail! Ship is escaped";
                break;
            }
            else if (path.IsShipDenied)
            {
                _firstStatus = "Fail! Engine is denied";
            }
        }

        return _firstStatus;
    }

    public string HowIsBetter()
    {
        foreach (Path path in _route)
        {
            path.IsPassed(_firstShip);
            if (path.Successful)
            {
                _firstSummaryFuel += path.FuelOnPath;
            }
            else
            {
                _firstStatus = "First is denied, Second is allowed";
                return _firstStatus;
            }

            if (_secondShip != null)
            {
                path.IsPassed(_secondShip);
            }

            if (path.Successful)
            {
                _secondSummaryFuel += path.FuelOnPath;
            }
            else
            {
                _secondStatus = "Second is denied, First is allowed";
                return _secondStatus;
            }
        }

        if (_firstSummaryFuel < _secondSummaryFuel)
        {
            return $"First is better";
        }
        else
        {
            return $"Second is better";
        }
    }
}