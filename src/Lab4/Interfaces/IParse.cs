using Itmo.ObjectOrientedProgramming.Lab4.Entity;
using Itmo.ObjectOrientedProgramming.Lab4.Service;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

public interface IParse
{
    public void Parse(Iterator iterator, ref SystemContext system);
}