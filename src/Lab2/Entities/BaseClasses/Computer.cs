namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class Computer
{
    private BIOS? _bios;
    private ComputerCase _case;
    private CoolingSystem _coolingSystem;
    private CPU _cpu;
    private GPU? _gpu;
    private HDD? _hdd;
    private MotherBoard _motherBoard;
    private PowerBlock _powerBlock;
    private RAM _ram;
    private SSD? _ssd;
    private WiFiAdapter? _wiFiAdapter;
    private XMP? _xmp;

    public Computer(BIOS? bios, ComputerCase computerCase, CoolingSystem coolingSystem, CPU cpu, GPU? gpu, HDD? hdd, MotherBoard motherBoard, PowerBlock powerBlock, RAM ram, SSD? ssd, WiFiAdapter? wiFiAdapter, XMP? xmp)
    {
        _bios = bios;
        _case = computerCase;
        _coolingSystem = coolingSystem;
        _cpu = cpu;
        _gpu = gpu;
        _hdd = hdd;
        _motherBoard = motherBoard;
        _powerBlock = powerBlock;
        _ram = ram;
        _ssd = ssd;
        _wiFiAdapter = wiFiAdapter;
        _xmp = xmp;
    }
}