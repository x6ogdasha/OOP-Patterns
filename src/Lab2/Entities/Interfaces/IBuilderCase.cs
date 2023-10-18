using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;

public interface IBuilderCase
{
    public void MaxVideoCardLength(int maxGPULength);
    public void MaxVideoCardWidth(int maxGPUWidth);
    public void Length(int length);
    public void Height(int height);
    public void Width(int width);
    public void SupportedMotherBoardFormFactor(IReadOnlyList<MotherBoardFormFactorType> motherBoardList);
    public BaseCase BuildCase();
}