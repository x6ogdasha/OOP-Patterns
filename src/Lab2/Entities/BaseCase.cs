using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class BaseCase
{
    private readonly List<string> _supportedMotherBoardFormFactor;

    public BaseCase()
    {
        _supportedMotherBoardFormFactor = new List<string>();
    }

    public int MaxVideoCardLength { get; protected set; }
    public int MaxVideoCardWidth { get; protected set; }
    public int Length { get; protected set; }
    public int Height { get; protected set; }
    public int Width { get; protected set; }
    public IReadOnlyList<string> SupportedMotherBoardFormFactor => _supportedMotherBoardFormFactor;
}