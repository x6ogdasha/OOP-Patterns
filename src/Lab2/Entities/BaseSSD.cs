using Itmo.ObjectOrientedProgramming.Lab2.Common;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class BaseSSD
{
    public MemoryConnectionType ConnectionType { get; protected set; }
    public int MemoryCapacity { get; protected set; }
    public int Speed { get; protected set; }
    public int Power { get; protected set; }
}