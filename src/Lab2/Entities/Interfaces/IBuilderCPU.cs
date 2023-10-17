using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;

public interface IBuilderCPU
{
    public void Socket(string socket);
    public void CoresNumber(int number);
    public void CoresFrequency(int frequency);
    public void InternalGPU(bool internalGPU);
    public void AllowedRAMFrequency(IReadOnlyList<string> allowedList);
    public void TDP(int tdp);
    public void Power(int power);
    public BaseCPU BuildCPU();
}