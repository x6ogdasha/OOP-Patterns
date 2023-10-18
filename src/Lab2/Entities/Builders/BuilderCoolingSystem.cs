using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;

public class BuilderCoolingSystem : IBuilderCoolingSystem
{
    private int _length;
    private int _width;
    private int _height;
    private IReadOnlyList<string> _supportedSockets;
    private int _tdp;

    public BuilderCoolingSystem(BaseCoolingSystem coolingSystem)
    {
        if (coolingSystem == null) throw new ArgumentNullException(nameof(coolingSystem));
        _length = coolingSystem.Length;
        _width = coolingSystem.Width;
        _height = coolingSystem.Height;
        _supportedSockets = coolingSystem.SupportedSockets;
        _tdp = coolingSystem.TDP;
    }

    public void Length(int length)
    {
        _length = length;
    }

    public void Width(int width)
    {
        _width = width;
    }

    public void Height(int height)
    {
        _height = height;
    }

    public void SupportedSockets(IReadOnlyList<string> supportedSockets)
    {
        _supportedSockets = supportedSockets;
    }

    public void TDP(int tdp)
    {
        _tdp = tdp;
    }

    public BaseCoolingSystem BuildCoolingSystem()
    {
        return new BaseCoolingSystem(_length, _width, _height, _supportedSockets, _tdp);
    }
}