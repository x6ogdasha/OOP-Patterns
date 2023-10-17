using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BaseCoolingSystem
{
    private readonly List<string> _supportedSocketsList;

    public BaseCoolingSystem()
    {
        _supportedSocketsList = new List<string>();
    }

    public int Length { get; protected set; }
    public int Width { get; protected set; }
    public int Height { get; protected set; }
    public IReadOnlyList<string> SupportedSockets => _supportedSocketsList;
    public int TDP { get; protected set; }
}