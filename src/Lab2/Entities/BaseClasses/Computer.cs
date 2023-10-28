namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class Computer
{
    public Computer(Bios? bios, ComputerCase computerCase, CoolingSystem coolingSystem, Cpu cpu, Gpu? gpu, Hdd? hdd, MotherBoard motherBoard, PowerBlock powerBlock, Ram ram, Ssd? ssd, WifiAdapter? wiFiAdapter, Xmp? xmp)
    {
        Bios = bios;
        ComputerCase = computerCase;
        CoolingSystem = coolingSystem;
        Cpu = cpu;
        Gpu = gpu;
        Hdd = hdd;
        MotherBoard = motherBoard;
        PowerBlock = powerBlock;
        Ram = ram;
        Ssd = ssd;
        WiFiAdapter = wiFiAdapter;
        Xmp = xmp;
    }

    public Bios? Bios { get; set; }
    public ComputerCase ComputerCase { get; set; }
    public CoolingSystem CoolingSystem { get; set; }
    public Cpu Cpu { get; set; }
    public Gpu? Gpu { get; set; }
    public Hdd? Hdd { get; set; }
    public MotherBoard MotherBoard { get; set; }
    public PowerBlock PowerBlock { get; set; }
    public Ram Ram { get; set; }
    public Ssd? Ssd { get; set; }
    public WifiAdapter? WiFiAdapter { get; set; }
    public Xmp? Xmp { get; set; }
}