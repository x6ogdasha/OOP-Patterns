using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BaseCase
{
    public BaseCase()
    {
        SupportedMotherBoardFormFactor = new List<MotherBoardFormFactorType>();
    }

    public BaseCase(int maxGpuLength, int maxGpuWidth, int length, int height, int width, IReadOnlyList<MotherBoardFormFactorType> supportedMotherBoards)
    {
        MaxVideoCardLength = maxGpuLength;
        MaxVideoCardWidth = maxGpuWidth;
        Length = length;
        Width = width;
        Height = height;
        SupportedMotherBoardFormFactor = supportedMotherBoards;
    }

    public int MaxVideoCardLength { get; protected set; }
    public int MaxVideoCardWidth { get; protected set; }
    public int Length { get; protected set; }
    public int Height { get; protected set; }
    public int Width { get; protected set; }
    public IReadOnlyList<MotherBoardFormFactorType> SupportedMotherBoardFormFactor { get; set; }
}