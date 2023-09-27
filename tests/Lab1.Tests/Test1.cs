using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test1
{
    [Fact]
    public void Test1Awgur()
    {
        // arrange
        string expected = "Fail! Ship is escaped";
        var ship = new Awgur();
        var secondShip = new PleasureShuttle();
        var environment = new HighDensityFog();
        var path = new Path(environment, 500);
        IList<Path> pathes = new List<Path>();
        pathes.Add(path);
        var route = new Route(ship, pathes);
        var secondRoute = new Route(secondShip, pathes);

        // act
        string status = route.IsRoutePassed();
        string secondStatus = secondRoute.IsRoutePassed();

        // assert
        Assert.Equal(expected, status);
        Assert.Equal(expected, secondStatus);
    }

    [Fact]
    public void Test2AntiMatterFlare()
    {
        // arrange
        var ship = new Waklas();
        var secondShip = new Waklas();
        secondShip.Deflector?.TurnOnPhotonDeflector();
        var environment = new HighDensityFog();
        var obstacle = new AntiMatterFlare();
        environment.AddObstacle(obstacle, 2);
        var path = new Path(environment, 250);
        IList<Path> pathes = new List<Path>();
        pathes.Add(path);
        var route = new Route(ship, pathes);
        var secondRoute = new Route(secondShip, pathes);

        // act
        string status = route.IsRoutePassed();
        string secondStatus = secondRoute.IsRoutePassed();

        // assert
        Assert.Equal("Fail! Crew is dead", status);
        Assert.Equal("Successful! Summary fuel: 62500, time: 1", secondStatus);
    }

    [Fact]
    public void Test3SpaceWhale()
    {
        // arrange
        var ship1 = new Waklas();
        var ship2 = new Awgur();
        var ship3 = new Meredian();
        var obstacle = new SpaceWhale();
        var environment = new NitrineParticleFog();
        environment.AddObstacle(obstacle, 1);
        var path = new Path(environment, 250);
        IList<Path> pathes = new List<Path>();
        pathes.Add(path);
        var route1 = new Route(ship1, pathes);
        var route2 = new Route(ship2, pathes);
        var route3 = new Route(ship3, pathes);

        // act
        string status1 = route1.IsRoutePassed();
        route2.IsRoutePassed();
        string status2 = ship2.Status;
        string status33 = route3.IsRoutePassed();
        string status3 = ship3.Status;

        // assert
        Assert.Equal("Fail! Ship is broken", status1);
        Assert.Equal("Deflector HP: 0, Shell HP: 100", status2);
        Assert.Equal("Successful! Summary fuel: 1250, time: 50 Deflector HP: 50, Shell HP: 25", status33 + " " + status3);
    }

    [Fact]
    public void Test4ShortSpace()
    {
        // arrange
        var ship1 = new PleasureShuttle();
        var ship2 = new Waklas();
        var environment = new Space();
        var path = new Path(environment, 200);
        IList<Path> pathes = new List<Path>();
        pathes.Add(path);
        var route = new Route(ship1, ship2, pathes);

        // act
        string status = route.HowIsBetter();

        // assert
        Assert.Equal("First is better", status);
    }

    [Fact]
    public void Test5MediumHighDensity()
    {
        // arrange
        var ship1 = new Awgur();
        var ship2 = new Stella();
        var environment = new HighDensityFog();
        var path = new Path(environment, 1000);
        IList<Path> pathes = new List<Path>();
        pathes.Add(path);
        var route = new Route(ship1, ship2, pathes);

        // act
        string status = route.HowIsBetter();

        // assert
        Assert.Equal("First is denied, Second is allowed", status);
    }

    [Fact]
    public void Test6NitrineParticle()
    {
        // arrange
        var ship1 = new PleasureShuttle();
        var ship2 = new Waklas();
        var environment = new NitrineParticleFog();
        var path = new Path(environment, 1000);
        IList<Path> pathes = new List<Path>();
        pathes.Add(path);
        var route = new Route(ship1, ship2, pathes);

        // act
        string status = route.HowIsBetter();

        // assert
        Assert.Equal("First is denied, Second is allowed", status);
    }

    [Fact]
    public void Test7ManyPath()
    {
        // arrange
        var ship1 = new Meredian();
        var environment1 = new Space();
        var environment2 = new NitrineParticleFog();
        var environment3 = new Space();
        var obstacle = new Meteorit();
        environment3.AddObstacle(obstacle, 2);
        var path1 = new Path(environment1, 100);
        var path2 = new Path(environment2, 300);
        var path3 = new Path(environment3, 150);
        IList<Path> pathes = new List<Path>();
        pathes.Add(path1);
        pathes.Add(path2);
        pathes.Add(path3);
        var route = new Route(ship1, pathes);

        // act
        string status = route.IsRoutePassed();
        string shipStatus = ship1.Status;

        // assert
        Assert.Equal("Deflector HP: 10, Shell HP: 25 Successful! Summary fuel: 2750, time: 110", shipStatus + " " + status);
    }
}