using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class MotherBoard : Prototype
{
    public MotherBoard(string socket, int numberOfPcie, int numberOfSata, string chipset, int standardOfDdr, int ramSlots, MotherBoardFormFactorType motherBoardFormFactor, BIOS bios)
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
    public BIOS BIOS { get; protected set; } = new BIOS();
    public override Prototype Clone()
    {
        return new MotherBoard(Socket, NumberOfPCIE, NumberOfSATA, Chipset, StandardOfDDR, RAMSlots, MotherBoardFormFactor, BIOS);
    }

    public Prototype CloneWithNewSocket(string newSocket)
    {
        return new MotherBoard(newSocket, NumberOfPCIE, NumberOfSATA, Chipset, StandardOfDDR, RAMSlots, MotherBoardFormFactor, BIOS);
    }

    public Prototype CloneWithNewConnectionSlots(int newSataNumber, int newPcieNumber)
    {
        return new MotherBoard(Socket, newPcieNumber, newSataNumber, Chipset, StandardOfDDR, RAMSlots, MotherBoardFormFactor, BIOS);
    }

    public Prototype CloneWithNewRam(int newRamStandard, int newRamSlots)
    {
        return new MotherBoard(Socket, NumberOfPCIE, NumberOfSATA, Chipset, newRamStandard, newRamSlots, MotherBoardFormFactor, BIOS);
    }

    public Prototype CloneWithNewChipset(string chipset)
    {
        return new MotherBoard(Socket, NumberOfPCIE, NumberOfSATA, chipset, StandardOfDDR, RAMSlots, MotherBoardFormFactor, BIOS);
    }

    public Prototype CloneWithNewFormFactor(MotherBoardFormFactorType newType)
    {
        return new MotherBoard(Socket, NumberOfPCIE, NumberOfSATA, Chipset, StandardOfDDR, RAMSlots, newType, BIOS);
    }

    public Prototype CloneWithNewBios(BIOS newBios)
    {
        return new MotherBoard(Socket, NumberOfPCIE, NumberOfSATA, Chipset, StandardOfDDR, RAMSlots, MotherBoardFormFactor, newBios);
    }
}