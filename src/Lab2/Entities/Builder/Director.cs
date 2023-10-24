using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builder;

public class Director
{
    private RepositoryContext _currentRepository = new RepositoryContext();
    private CreateComponents _service;
    private ComputerBuilder _builder;
    public Director()
    {
        _builder = new ComputerBuilder();
        _service = new CreateComponents(_currentRepository);
    }

    public void BuildComputer(string motherName, string cpuName, string? biosName, string coolingName, string ramName, string? xmpName, string? gpuName, string? ssdName, string? hddName, string caseName, string powerName, string? wifiName)
    {
        _builder.MotherBoard(_service.Repository.MotherRepository.Read(motherName) ?? throw new InvalidOperationException());
        _builder.CPU(_service.Repository.CpuRepository.Read(cpuName) ?? throw new InvalidOperationException());
        _builder.BIOS(_service.Repository.BiosRepository.Read(biosName));
        _builder.CoolingSystem(_service.Repository.CoolingRepository.Read(coolingName) ?? throw new InvalidOperationException());
        _builder.RAM(_service.Repository.RamRepository.Read(ramName) ?? throw new InvalidOperationException());
        _builder.XMP(_service.Repository.XmpRepository.Read(xmpName));
        _builder.GPU(_service.Repository.GpuRepository.Read(gpuName));
        _builder.SSD(_service.Repository.SsdRepository.Read(ssdName));
        _builder.HDD(_service.Repository.HddRepository.Read(hddName));
        _builder.ComputerCase(_service.Repository.CaseRepository.Read(caseName) ?? throw new InvalidOperationException());
        _builder.PowerBlock(_service.Repository.PowerRepository.Read(powerName) ?? throw new InvalidOperationException());
        _builder.WiFiAdapter(_service.Repository.WifiRepository.Read(wifiName));
    }
}