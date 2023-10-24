namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class Computer
{
    public Computer(BIOS? bios, ComputerCase computerCase, CoolingSystem coolingSystem, CPU cpu, GPU? gpu, HDD? hdd, MotherBoard motherBoard, PowerBlock powerBlock, RAM ram, SSD? ssd, WiFiAdapter? wiFiAdapter, XMP? xmp)
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

    public BIOS? Bios { get; set; }
    public ComputerCase ComputerCase { get; set; }
    public CoolingSystem CoolingSystem { get; set; }
    public CPU Cpu { get; set; }
    public GPU? Gpu { get; set; }
    public HDD? Hdd { get; set; }
    public MotherBoard MotherBoard { get; set; }
    public PowerBlock PowerBlock { get; set; }
    public RAM Ram { get; set; }
    public SSD? Ssd { get; set; }
    public WiFiAdapter? WiFiAdapter { get; set; }
    public XMP? Xmp { get; set; }
}