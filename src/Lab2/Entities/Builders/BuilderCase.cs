using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;

public class BuilderCase : IBuilderCase
{
    private int _maxVideoCardLength;
    private int _maxVideoCardWidth;
    private int _length;
    private int _height;
    private int _width;
    private IReadOnlyList<MotherBoardFormFactorType> _supportedMothers;

    public BuilderCase(BaseCase computerCase)
    {
        if (computerCase == null) throw new ArgumentNullException(nameof(computerCase));
        _maxVideoCardLength = computerCase.MaxVideoCardLength;
        _maxVideoCardWidth = computerCase.MaxVideoCardWidth;
        _length = computerCase.Length;
        _width = computerCase.Width;
        _height = computerCase.Height;
        _supportedMothers = computerCase.SupportedMotherBoardFormFactor;
    }

    public void MaxVideoCardLength(int maxGPULength)
    {
        _maxVideoCardLength = maxGPULength;
    }

    public void MaxVideoCardWidth(int maxGPUWidth)
    {
        _maxVideoCardWidth = maxGPUWidth;
    }

    public void Length(int length)
    {
        _length = length;
    }

    public void Height(int height)
    {
        _height = height;
    }

    public void Width(int width)
    {
        _width = width;
    }

    public void SupportedMotherBoardFormFactor(IReadOnlyList<MotherBoardFormFactorType> motherBoardList)
    {
        _supportedMothers = motherBoardList;
    }

    public BaseCase BuildCase()
    {
        return new BaseCase(_maxVideoCardLength, _maxVideoCardWidth, _length, _height, _width, _supportedMothers);
    }
}