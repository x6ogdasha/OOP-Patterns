using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BaseBIOS
{
    public BaseBIOS()
    {
        SupportedCPUs = new List<string>();
        Version = "null";
    }

    public BaseBIOS(BIOSType type, string version, IReadOnlyList<string> supportedCPUs)
    {
        Type = type;
        Version = version;
        SupportedCPUs = supportedCPUs;
    }

    public BIOSType Type { get; protected set; }
    public string Version { get; protected set; }
    public IReadOnlyList<string> SupportedCPUs { get; set; }
}