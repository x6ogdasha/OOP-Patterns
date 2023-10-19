using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class CoolingSystem : Prototype
{
    public CoolingSystem()
    {
        SupportedSockets = new List<string>();
    }

    public CoolingSystem(int length, int width, int height, IReadOnlyList<string> supportedSockets, int tdp)
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
    public override Prototype Clone()
    {
        return new CoolingSystem(Length, Width, Height, SupportedSockets, TDP);
    }

    public Prototype CloneWithNewSize(int newLength, int newWidth, int newHeight)
    {
        return new CoolingSystem(newLength, newWidth, newHeight, SupportedSockets, TDP);
    }

    public Prototype CloneWithNewSupportedSockets(IReadOnlyList<string> newAllowedList)
    {
        return new CoolingSystem(Length, Width, Height, newAllowedList, TDP);
    }

    public Prototype CloneWithNewTdp(int newTdp)
    {
        return new CoolingSystem(Length, Width, Height, SupportedSockets, newTdp);
    }
}