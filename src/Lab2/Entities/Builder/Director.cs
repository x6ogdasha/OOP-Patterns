using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builder;

public class Director
{
    private RepositoryContext _currentRepository = new RepositoryContext();
    private Seeding _service;
    public Director()
    {
        _service = new Seeding(_currentRepository);
    }

    public ComputerBuilder Builder { get; set; } = new ComputerBuilder();

    public Computer BuildComputer(string motherName, string cpuName, string? biosName, string coolingName, string ramName, string? xmpName, string? gpuName, string? ssdName, string? hddName, string caseName, string powerName, string? wifiName)
    {
        Builder.MotherBoard(_service.Repository.MotherRepository.Read(motherName) ?? throw new InvalidOperationException());
        Builder.Cpu(_service.Repository.CpuRepository.Read(cpuName) ?? throw new InvalidOperationException());
        Builder.Bios(_service.Repository.BiosRepository.Read(biosName));
        Builder.CoolingSystem(_service.Repository.CoolingRepository.Read(coolingName) ?? throw new InvalidOperationException());
        Builder.Ram(_service.Repository.RamRepository.Read(ramName) ?? throw new InvalidOperationException());
        Builder.Xmp(_service.Repository.XmpRepository.Read(xmpName));
        Builder.Gpu(_service.Repository.GpuRepository.Read(gpuName));
        Builder.Ssd(_service.Repository.SsdRepository.Read(ssdName));
        Builder.Hdd(_service.Repository.HddRepository.Read(hddName));
        Builder.ComputerCase(_service.Repository.CaseRepository.Read(caseName) ?? throw new InvalidOperationException());
        Builder.PowerBlock(_service.Repository.PowerRepository.Read(powerName) ?? throw new InvalidOperationException());
        Builder.WiFiAdapter(_service.Repository.WifiRepository.Read(wifiName));
        return Builder.Build();
    }
}