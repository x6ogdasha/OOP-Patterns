using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class ComputerCase : Prototype
{
    public ComputerCase()
    {
        SupportedMotherBoardFormFactor = new List<MotherBoardFormFactorType>();
    }

    public ComputerCase(int maxGpuLength, int maxGpuWidth, int length, int height, int width, IReadOnlyList<MotherBoardFormFactorType> supportedMotherBoards)
    {
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
    public override Prototype Clone()
    {
        return new ComputerCase(MaxGPULength, MaxGPUWidth, Length, Height, Width, SupportedMotherBoardFormFactor);
    }

    public Prototype CloneWithNewMaxGpuSize(int gpuLength, int gpuWidth)
    {
        return new ComputerCase(gpuLength, gpuWidth, Length, Height, Width, SupportedMotherBoardFormFactor);
    }

    public Prototype CloneWithNewSize(int newLength, int newHeight, int newWidth)
    {
        return new ComputerCase(MaxGPULength, MaxGPUWidth, newLength, newHeight, newWidth, SupportedMotherBoardFormFactor);
    }

    public Prototype CloneWithNewSupportedFormFactors(IReadOnlyList<MotherBoardFormFactorType> newSupportedList)
    {
        return new ComputerCase(MaxGPULength, MaxGPUWidth, Length, Height, Width, newSupportedList);
    }
}