using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BaseCoolingSystem
{
    public BaseCoolingSystem()
    {
        SupportedSockets = new List<string>();
    }

    public BaseCoolingSystem(int length, int width, int height, IReadOnlyList<string> supportedSockets, int tdp)
    {
        Length = length;
        Width = width;
        Height = height;
        SupportedSockets = supportedSockets;
        TDP = tdp;
    }

    public int Length { get; protected set; }
    public int Width { get; protected set; }
    public int Height { get; protected set; }
    public IReadOnlyList<string> SupportedSockets { get; set; }
    public int TDP { get; protected set; }
}