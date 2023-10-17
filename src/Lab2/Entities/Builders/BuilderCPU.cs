using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;

public sealed class BuilderCPU : IBuilderCPU
{
    private string _socketName;
    private int _coreNumber;
    private int _coreFrequency;
    private bool _internalGPU;
    private IReadOnlyList<string> _allowedList;
    private int _tdp;
    private int _power;

    public BuilderCPU()
    {
        _socketName = "null";
        _allowedList = new List<string>();
    }

    public void Socket(string socket)
    {
        _socketName = socket;
    }

    public void CoresNumber(int number)
    {
        _coreNumber = number;
    }

    public void CoresFrequency(int frequency)
    {
        _coreFrequency = frequency;
    }

    public void InternalGPU(bool internalGPU)
    {
        _internalGPU = internalGPU;
    }

    public void AllowedRAMFrequency(IReadOnlyList<string> allowedList)
    {
        _allowedList = allowedList;
    }

    public void TDP(int tdp)
    {
        _tdp = tdp;
    }

    public void Power(int power)
    {
        _power = power;
    }

    public BaseCPU BuildCPU()
    {
        return new BaseCPU(_socketName, _coreNumber, _coreFrequency, _internalGPU, _allowedList, _tdp, _power);
    }
}