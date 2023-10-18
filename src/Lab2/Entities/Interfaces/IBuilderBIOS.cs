using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;

public interface IBuilderBIOS
{
    public void BIOSType(BIOSType type);
    public void Version(string version);
    public void SupportedCPUs(IReadOnlyList<string> supportedList);

    public BaseBIOS BuildBIOS();
}