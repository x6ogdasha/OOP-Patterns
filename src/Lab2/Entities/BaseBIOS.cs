using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class BaseBIOS
{
    private readonly List<string> _supportedCPUsList;

    public BaseBIOS()
    {
        _supportedCPUsList = new List<string>();
    }

    public BIOSType Type { get; protected set; }
    public string? Version { get; protected set; }
    public IReadOnlyList<string> SupportedCPUs => _supportedCPUsList;
}