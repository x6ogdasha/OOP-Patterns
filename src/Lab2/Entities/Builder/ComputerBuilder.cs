using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builder;

public class ComputerBuilder
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

    public ComputerBuilder()
    {
        _case = new ComputerCase();
        _coolingSystem = new CoolingSystem();
        _cpu = new CPU();
        _motherBoard = new MotherBoard();
        _powerBlock = new PowerBlock();
        _ram = new RAM();
    }

    public void BIOS(BIOS? bios)
    {
        _bios = bios;
    }

    public void ComputerCase(ComputerCase computerCase)
    {
        _case = computerCase;
    }

    public void CoolingSystem(CoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;
    }

    public void CPU(CPU cpu)
    {
        _cpu = cpu;
    }

    public void GPU(GPU? gpu)
    {
        _gpu = gpu;
    }

    public void HDD(HDD? hdd)
    {
        _hdd = hdd;
    }

    public void MotherBoard(MotherBoard motherBoard)
    {
        _motherBoard = motherBoard;
    }

    public void PowerBlock(PowerBlock powerBlock)
    {
        _powerBlock = powerBlock;
    }

    public void RAM(RAM ram)
    {
        _ram = ram;
    }

    public void SSD(SSD? ssd)
    {
        _ssd = ssd;
    }

    public void WiFiAdapter(WiFiAdapter? wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
    }

    public void XMP(XMP? xmp)
    {
        _xmp = xmp;
    }

    public Computer Build()
    {
        return new Computer(_bios, _case, _coolingSystem, _cpu, _gpu, _hdd, _motherBoard, _powerBlock, _ram, _ssd, _wiFiAdapter, _xmp);
    }
}