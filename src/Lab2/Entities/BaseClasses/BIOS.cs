using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BIOS : BaseComponent, IPrototype, IEquatable<BIOS>
{
    public BIOS()
    {
        SupportedCPUs = new List<string>();
        Version = "null";
    }

    public BIOS(string name, BIOSType type, string version, IReadOnlyList<string> supportedCPUs)
    {
        Name = name;
        Type = type;
        Version = version;
        SupportedCPUs = supportedCPUs;
    }

    public BIOSType Type { get; set; }
    public string Version { get; protected set; }
    public IReadOnlyList<string> SupportedCPUs { get; set; }
    public IPrototype Clone()
    {
        return new BIOS(Name, Type, Version, SupportedCPUs);
    }

    public IPrototype CloneWithNewVersion(string newVersion, string newName)
    {
        return new BIOS(newName, Type, newVersion, SupportedCPUs);
    }

    public IPrototype CloneWithNewAllowedList(IReadOnlyList<string> newList, string newName)
    {
        return new BIOS(newName, Type, Version, newList);
    }

    public bool Equals(BIOS? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Type == other.Type && Version == other.Version && SupportedCPUs.Equals(other.SupportedCPUs);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not BIOS) return false;
        return Equals((BIOS)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)Type, Version, SupportedCPUs);
    }
}