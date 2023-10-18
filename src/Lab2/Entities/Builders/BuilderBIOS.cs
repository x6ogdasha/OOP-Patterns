using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;

public class BuilderBIOS : IBuilderBIOS
{
    private BIOSType _biosType;
    private string _version;
    private IReadOnlyList<string> _supportedCPUs;

    public BuilderBIOS()
    {
        _version = "null";
        _supportedCPUs = new List<string>();
    }

    public BuilderBIOS(BaseBIOS bios)
    {
        if (bios is null) throw new ArgumentNullException(nameof(bios));
        _biosType = bios.Type;
        _version = bios.Version;
        _supportedCPUs = bios.SupportedCPUs;
    }

    public void BIOSType(BIOSType type)
    {
        _biosType = type;
    }

    public void Version(string version)
    {
        _version = version;
    }

    public void SupportedCPUs(IReadOnlyList<string> supportedList)
    {
        _supportedCPUs = supportedList;
    }

    public BaseBIOS BuildBIOS()
    {
        return new BaseBIOS(_biosType, _version, _supportedCPUs);
    }
}