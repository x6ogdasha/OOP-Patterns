using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class ComputerCase : BaseComponent, IPrototype, IEquatable<ComputerCase>
{
    public ComputerCase()
    {
        SupportedMotherBoardFormFactor = new List<MotherBoardFormFactorType>();
    }

    public ComputerCase(string name, int maxGpuLength, int maxGpuWidth, int length, int height, int width, IReadOnlyList<MotherBoardFormFactorType> supportedMotherBoards)
    {
        Name = name;
        MaxGPULength = maxGpuLength;
        MaxGPUWidth = maxGpuWidth;
        Length = length;
        Width = width;
        Height = height;
        SupportedMotherBoardFormFactor = supportedMotherBoards;
    }

    public int MaxGPULength { get; protected set; }
    public int MaxGPUWidth { get; protected set; }
    public int Length { get; protected set; }
    public int Height { get; protected set; }
    public int Width { get; protected set; }
    public IReadOnlyList<MotherBoardFormFactorType> SupportedMotherBoardFormFactor { get; set; }
    public IPrototype Clone()
    {
        return new ComputerCase(Name, MaxGPULength, MaxGPUWidth, Length, Height, Width, SupportedMotherBoardFormFactor);
    }

    public IPrototype CloneWithNewMaxGpuSize(int gpuLength, int gpuWidth, string newName)
    {
        return new ComputerCase(newName, gpuLength, gpuWidth, Length, Height, Width, SupportedMotherBoardFormFactor);
    }

    public IPrototype CloneWithNewSize(int newLength, int newHeight, int newWidth, string newName)
    {
        return new ComputerCase(newName, MaxGPULength, MaxGPUWidth, newLength, newHeight, newWidth, SupportedMotherBoardFormFactor);
    }

    public IPrototype CloneWithNewSupportedFormFactors(IReadOnlyList<MotherBoardFormFactorType> newSupportedList, string newName)
    {
        return new ComputerCase(newName, MaxGPULength, MaxGPUWidth, Length, Height, Width, newSupportedList);
    }

    public bool Equals(ComputerCase? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return MaxGPULength == other.MaxGPULength && MaxGPUWidth == other.MaxGPUWidth && Length == other.Length && Height == other.Height && Width == other.Width && SupportedMotherBoardFormFactor.Equals(other.SupportedMotherBoardFormFactor);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not ComputerCase) return false;
        return Equals((ComputerCase)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(MaxGPULength, MaxGPUWidth, Length, Height, Width, SupportedMotherBoardFormFactor);
    }
}