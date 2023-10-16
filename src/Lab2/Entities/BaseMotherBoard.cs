using Itmo.ObjectOrientedProgramming.Lab2.Common;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class BaseMotherBoard
{
    public string? Socket { get; protected set; }
    public int NumberOfPCIE { get; protected set; }
    public int NumberOfSATA { get; protected set; }
    public string? Chipset { get; protected set; }
    public int StandardOfDDR { get; protected set; }
    public int RAMSlots { get; protected set; }
    public MotherBoardFormFactorType MotherBoardFormFactor { get; protected set; }
    public BaseBIOS BIOS { get; protected set; } = new BaseBIOS();
}