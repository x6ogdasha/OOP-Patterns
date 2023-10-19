using Itmo.ObjectOrientedProgramming.Lab2.Common;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BaseMotherBoard
{
    public BaseMotherBoard(string socket, int numberOfPcie, int numberOfSata, string chipset, int standardOfDdr, int ramSlots, MotherBoardFormFactorType motherBoardFormFactor, BaseBIOS bios)
    {
        Socket = socket;
        NumberOfSATA = numberOfSata;
        NumberOfPCIE = numberOfPcie;
        Chipset = chipset;
        StandardOfDDR = standardOfDdr;
        RAMSlots = ramSlots;
        MotherBoardFormFactor = motherBoardFormFactor;
        BIOS = bios;
    }

    public string Socket { get; protected set; }
    public int NumberOfPCIE { get; protected set; }
    public int NumberOfSATA { get; protected set; }
    public string Chipset { get; protected set; }
    public int StandardOfDDR { get; protected set; }
    public int RAMSlots { get; protected set; }
    public MotherBoardFormFactorType MotherBoardFormFactor { get; protected set; }
    public BaseBIOS BIOS { get; protected set; } = new BaseBIOS();
}