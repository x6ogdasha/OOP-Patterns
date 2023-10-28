using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builder;

public class ComputerBuilder
{
    private Bios? _bios;
    private ComputerCase _case;
    private CoolingSystem _coolingSystem;
    private Cpu _cpu;
    private Gpu? _gpu;
    private Hdd? _hdd;
    private MotherBoard _motherBoard;
    private PowerBlock _powerBlock;
    private Ram _ram;
    private Ssd? _ssd;
    private WifiAdapter? _wiFiAdapter;
    private Xmp? _xmp;

    public ComputerBuilder()
    {
        _case = new ComputerCase();
        _coolingSystem = new CoolingSystem();
        _cpu = new Cpu();
        _motherBoard = new MotherBoard();
        _powerBlock = new PowerBlock();
        _ram = new Ram();
        StatusOfBuilding = Status.Successful;
    }

    public ComputerBuilder(Computer computer)
    {
        if (computer is null) throw new ArgumentNullException(nameof(computer));
        _bios = computer.Bios;
        _case = computer.ComputerCase;
        _coolingSystem = computer.CoolingSystem;
        _cpu = computer.Cpu;
        _gpu = computer.Gpu;
        _hdd = computer.Hdd;
        _motherBoard = computer.MotherBoard;
        _powerBlock = computer.PowerBlock;
        _ram = computer.Ram;
        _ssd = computer.Ssd;
        _wiFiAdapter = computer.WiFiAdapter;
        _xmp = computer.Xmp;
    }

    public Status? StatusOfBuilding { get; set; }

    public void Bios(Bios? bios)
    {
        if (bios is not null && bios.SupportedCPUs.Contains(_cpu.SocketName))
        {
            _bios = bios;
        }
        else if (bios is not null)
        {
            StatusOfBuilding = Status.FailWithBIOS;
        }
    }

    public void ComputerCase(ComputerCase computerCase)
    {
        if (computerCase == null) throw new ArgumentNullException(nameof(computerCase));

        switch (_gpu)
        {
            case not null when _gpu.Height <= computerCase.MaxGPULength && computerCase.SupportedMotherBoardFormFactor.Contains(_motherBoard.MotherBoardFormFactor):
                _case = computerCase;
                break;
            case null when computerCase.SupportedMotherBoardFormFactor.Contains(_motherBoard.MotherBoardFormFactor):
                _case = computerCase;
                break;

            default:
                StatusOfBuilding = Status.FailWithCase;
                break;
        }
    }

    public void CoolingSystem(CoolingSystem coolingSystem)
    {
        if (coolingSystem is null) throw new ArgumentNullException(nameof(coolingSystem));

        if (coolingSystem.SupportedSockets.Contains(_motherBoard.Socket))
        {
            _coolingSystem = coolingSystem;
            if (coolingSystem.TDP < _cpu.TDP) StatusOfBuilding = Status.GuaranteeOff;
        }
        else
        {
            StatusOfBuilding = Status.FailWithCooler;
            return;
        }
    }

    public void Cpu(Cpu cpu)
    {
        if (cpu is null) throw new ArgumentNullException(nameof(cpu));

        if (cpu.SocketName == _motherBoard.Socket && _motherBoard.BIOS.SupportedCPUs.Contains(cpu.SocketName))
        {
            _cpu = cpu;
        }
        else
        {
            StatusOfBuilding = Status.FailWithCPU;
        }
    }

    public void Gpu(Gpu? gpu)
    {
        if (gpu is null && !_cpu.InternalGPU)
        {
            StatusOfBuilding = Status.FailWithGPU;
        }

        if (gpu is not null)
        {
            _gpu = gpu;
        }
    }

    public void Hdd(Hdd? hdd)
    {
        if (hdd is not null && _motherBoard.NumberOfSATA > 0)
        {
            _hdd = hdd;
        }
        else if (hdd is not null)
        {
            StatusOfBuilding = Status.FailWithHDD;
        }
    }

    public void MotherBoard(MotherBoard motherBoard)
    {
        _motherBoard = motherBoard;
    }

    public void PowerBlock(PowerBlock powerBlock)
    {
        if (powerBlock is null) throw new ArgumentNullException(nameof(powerBlock));

        if (_cpu is not null && _gpu is not null &&
            _cpu.Power + _gpu.Power <= powerBlock.Power)
        {
            _powerBlock = powerBlock;
        }
        else
        {
            StatusOfBuilding = Status.WarningWithPower;
        }
    }

    public void Ram(Ram ram)
    {
        if (ram is null) throw new ArgumentNullException(nameof(ram));

        if (_motherBoard.StandardOfDDR == ram.StandardOfDDR)
        {
            _ram = ram;
        }
        else
        {
            StatusOfBuilding = Status.FailWithRAM;
        }
    }

    public void Ssd(Ssd? ssd)
    {
        if (ssd is not null && _motherBoard.NumberOfPCIE > 0)
        {
            _ssd = ssd;
        }
        else if (ssd is not null)
        {
            StatusOfBuilding = Status.FailWithSSD;
        }
    }

    public void WiFiAdapter(WifiAdapter? wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
    }

    public void Xmp(Xmp? xmp)
    {
        _xmp = xmp;
    }

    public Computer Build()
    {
        return new Computer(_bios, _case, _coolingSystem, _cpu, _gpu, _hdd, _motherBoard, _powerBlock, _ram, _ssd, _wiFiAdapter, _xmp);
    }
}