using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class CoolingSystem : BaseComponent, IPrototype, IEquatable<CoolingSystem>
{
    public CoolingSystem()
    {
        SupportedSockets = new List<string>();
    }

    public CoolingSystem(string name, int length, int width, int height, IReadOnlyList<string> supportedSockets, int tdp)
    {
        Name = name;
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
    public IPrototype Clone()
    {
        return new CoolingSystem(Name, Length, Width, Height, SupportedSockets, TDP);
    }

    public IPrototype CloneWithNewSize(int newLength, int newWidth, int newHeight, string newName)
    {
        return new CoolingSystem(newName, newLength, newWidth, newHeight, SupportedSockets, TDP);
    }

    public IPrototype CloneWithNewSupportedSockets(IReadOnlyList<string> newAllowedList, string newName)
    {
        return new CoolingSystem(newName, Length, Width, Height, newAllowedList, TDP);
    }

    public IPrototype CloneWithNewTdp(int newTdp, string newName)
    {
        return new CoolingSystem(newName, Length, Width, Height, SupportedSockets, newTdp);
    }

    public bool Equals(CoolingSystem? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Length == other.Length && Width == other.Width && Height == other.Height && SupportedSockets.Equals(other.SupportedSockets) && TDP == other.TDP;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not CoolingSystem) return false;
        return Equals((CoolingSystem)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Length, Width, Height, SupportedSockets, TDP);
    }
}