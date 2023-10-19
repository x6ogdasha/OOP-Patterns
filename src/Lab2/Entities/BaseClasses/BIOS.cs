using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BIOS : Prototype
{
    public BIOS()
    {
        SupportedCPUs = new List<string>();
        Version = "null";
    }

    public BIOS(BIOSType type, string version, IReadOnlyList<string> supportedCPUs)
    {
        Type = type;
        Version = version;
        SupportedCPUs = supportedCPUs;
    }

    public BIOSType Type { get; set; }
    public string Version { get; protected set; }
    public IReadOnlyList<string> SupportedCPUs { get; set; }
    public override Prototype Clone()
    {
        return new BIOS(Type, Version, SupportedCPUs);
    }

    public Prototype CloneWithNewVersion(string newVersion)
    {
        return new BIOS(Type, newVersion, SupportedCPUs);
    }

    public Prototype CloneWithNewAllowedList(IReadOnlyList<string> newList)
    {
        return new BIOS(Type, Version, newList);
    }
}