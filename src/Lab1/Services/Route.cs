using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Helpers;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Route
{
    private IList<Path> _route;
    private BaseShip _firstShip;
    private BaseShip? _secondShip;
    private double _firstSummaryFuel;
    private double? _firstSummaryTime;
    private double _secondSummaryFuel;
    private Status _firstStatus;
    private Status _secondStatus;

    public Route(BaseShip ship, IList<Path> route)
    {
        _route = route;
        _firstShip = ship;
        _firstSummaryFuel = 0;
        _firstSummaryTime = 0;
        _firstStatus = Status.Null;
        _secondStatus = Status.Null;
    }

    public Route(BaseShip firstShip, BaseShip secondShip, IList<Path> route)
    {
        _route = route;
        _firstShip = firstShip;
        _secondShip = secondShip;
        _firstSummaryFuel = 0;
        _secondSummaryFuel = 0;
        _firstSummaryTime = 0;
        _firstStatus = Status.Null;
        _secondStatus = Status.Null;
    }

    public Status IsRoutePassed()
    {
        foreach (Path path in _route)
        {
            path.IsPassed(_firstShip);
            if (path.Successful)
            {
                _firstSummaryFuel += path.FuelOnPath;
                _firstSummaryTime += path.TimeOnPath;
                _firstStatus = Status.Successful;
            }
            else if (path.CrewIsDead)
            {
                _firstStatus = Status.CrewIsDead;
                break;
            }
            else if (path.ShipIsBroken)
            {
                _firstStatus = Status.ShipIsBroken;
                break;
            }
            else if (path.ShipIsEscaped)
            {
                _firstStatus = Status.ShipIsEscaped;
                break;
            }
            else if (path.IsShipDenied)
            {
                _firstStatus = Status.EngineIsDenied;
            }
        }

        return _firstStatus;
    }

    public Status HowIsBetter()
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
                _firstStatus = Status.SecondIsAllowed;
                return _firstStatus;
            }

            if (_secondShip is not null)
            {
                path.IsPassed(_secondShip);
            }

            if (path.Successful)
            {
                _secondSummaryFuel += path.FuelOnPath;
            }
            else
            {
                _secondStatus = Status.FirstIsAllowed;
                return _secondStatus;
            }
        }

        if (_firstSummaryFuel < _secondSummaryFuel)
        {
            return Status.FirstIsBetter;
        }
        else
        {
            return Status.SecondIsBetter;
        }
    }
}