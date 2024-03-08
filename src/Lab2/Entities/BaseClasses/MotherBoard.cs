using System;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class MotherBoard : BaseComponent, IPrototype, IEquatable<MotherBoard>
{
    public MotherBoard()
    {
        Socket = string.Empty;
        Chipset = string.Empty;
    }

    public MotherBoard(string name, string socket, int numberOfPcie, int numberOfSata, string chipset, int standardOfDdr, int ramSlots, MotherBoardFormFactorType motherBoardFormFactor, Bios bios)
    {
        Name = name;
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
    public Bios BIOS { get; protected set; } = new Bios();
    public IPrototype Clone()
    {
        return new MotherBoard(Name, Socket, NumberOfPCIE, NumberOfSATA, Chipset, StandardOfDDR, RAMSlots, MotherBoardFormFactor, BIOS);
    }

    public IPrototype CloneWithNewSocket(string newSocket, string newName)
    {
        return new MotherBoard(newName, newSocket, NumberOfPCIE, NumberOfSATA, Chipset, StandardOfDDR, RAMSlots, MotherBoardFormFactor, BIOS);
    }

    public IPrototype CloneWithNewConnectionSlots(int newSataNumber, int newPcieNumber, string newName)
    {
        return new MotherBoard(newName, Socket, newPcieNumber, newSataNumber, Chipset, StandardOfDDR, RAMSlots, MotherBoardFormFactor, BIOS);
    }

    public IPrototype CloneWithNewRam(int newRamStandard, int newRamSlots, string newName)
    {
        return new MotherBoard(newName, Socket, NumberOfPCIE, NumberOfSATA, Chipset, newRamStandard, newRamSlots, MotherBoardFormFactor, BIOS);
    }

    public IPrototype CloneWithNewChipset(string chipset, string newName)
    {
        return new MotherBoard(newName, Socket, NumberOfPCIE, NumberOfSATA, chipset, StandardOfDDR, RAMSlots, MotherBoardFormFactor, BIOS);
    }

    public IPrototype CloneWithNewFormFactor(MotherBoardFormFactorType newType, string newName)
    {
        return new MotherBoard(newName, Socket, NumberOfPCIE, NumberOfSATA, Chipset, StandardOfDDR, RAMSlots, newType, BIOS);
    }

    public IPrototype CloneWithNewBios(Bios newBios, string newName)
    {
        return new MotherBoard(newName, Socket, NumberOfPCIE, NumberOfSATA, Chipset, StandardOfDDR, RAMSlots, MotherBoardFormFactor, newBios);
    }

    public bool Equals(MotherBoard? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Socket == other.Socket && NumberOfPCIE == other.NumberOfPCIE && NumberOfSATA == other.NumberOfSATA && Chipset == other.Chipset && StandardOfDDR == other.StandardOfDDR && RAMSlots == other.RAMSlots && MotherBoardFormFactor == other.MotherBoardFormFactor && BIOS.Equals(other.BIOS);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not MotherBoard) return false;
        return Equals((MotherBoard)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Socket, NumberOfPCIE, NumberOfSATA, Chipset, StandardOfDDR, RAMSlots, (int)MotherBoardFormFactor, BIOS);
    }
}