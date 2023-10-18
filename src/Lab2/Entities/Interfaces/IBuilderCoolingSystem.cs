using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;

public interface IBuilderCoolingSystem
{
    public void Length(int length);
    public void Width(int width);
    public void Height(int height);
    public void SupportedSockets(IReadOnlyList<string> supportedSockets);
    public void TDP(int tdp);
    public BaseCoolingSystem BuildCoolingSystem();
}