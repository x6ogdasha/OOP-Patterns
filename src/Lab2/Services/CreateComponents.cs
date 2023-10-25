using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class CreateComponents
{
    public CreateComponents(RepositoryContext repository)
    {
        Repository = repository;
        AddComponents();
    }

    public RepositoryContext Repository { get; }

    public void AddComponents()
    {
        CreateBios();
        CreateComputerCases();
        CreateComputerCases();
        CreateCoolingSystem();
        CreateCPU();
        CreateGPU();
        CreateHDD();
        CreateMotherBoard();
        CreatePowerBlock();
        CreateRAM();
        CreateSSD();
        CreateWiFiAdapter();
        CreateXMP();
    }

    private void CreateBios()
    {
        Repository.BiosRepository.Create(new BIOS(
            "ASUS BIOS",
            BIOSType.UEFI,
            "2.0",
            new List<string>() { "Intel Core i9", "AM4" }));
        Repository.BiosRepository.Create(new BIOS(
            "MSI BIOS",
            BIOSType.Legacy,
            "1.5",
            new List<string>() { "Intel Core i7", "AM5" }));
        Repository.BiosRepository.Create(new BIOS(
            "Gigabyte BIOS",
            BIOSType.UEFI,
            "3.1",
            new List<string>() { "LGA1700", "AM5" }));
    }

    private void CreateComputerCases()
    {
        Repository.CaseRepository.Create(new ComputerCase(
            "Mid-Tower case",
            350,
            140,
            450,
            200,
            200,
            new List<MotherBoardFormFactorType> { MotherBoardFormFactorType.ATX, MotherBoardFormFactorType.MiniATX }));
        Repository.CaseRepository.Create(new ComputerCase(
            "Mini case",
            250,
            120,
            350,
            150,
            200,
            new List<MotherBoardFormFactorType> { MotherBoardFormFactorType.MiniITX }));
        Repository.CaseRepository.Create(new ComputerCase(
            "Versatile case",
            400,
            160,
            500,
            220,
            230,
            new List<MotherBoardFormFactorType> { MotherBoardFormFactorType.ATX, MotherBoardFormFactorType.MicroATX, MotherBoardFormFactorType.MiniITX }));
    }

    private void CreateCoolingSystem()
    {
        Repository.CoolingRepository.Create(new CoolingSystem(
            "Air Cooler",
            160,
            120,
            75,
            new List<string> { "LGA1700", "AM4" },
            95));
        Repository.CoolingRepository.Create(new CoolingSystem(
            "Liquid Cooler",
            240,
            120,
            30,
            new List<string> { "LGA1700", "AM5", "AM4" },
            150));
        Repository.CoolingRepository.Create(new CoolingSystem(
            "High-Perfomance Cooler",
            180,
            140,
            80,
            new List<string> { "LGA2066", "AM5" },
            200));
    }

    private void CreateCPU()
    {
        Repository.CpuRepository.Create(new CPU(
            "Intel Core i5-11600k",
            "LGA1200",
            6,
            3900,
            true,
            new List<string> { "3200", "2933" },
            95,
            65));
        Repository.CpuRepository.Create(new CPU(
            "AMD Ryzen 7 5700G",
            "AM4",
            8,
            3800,
            true,
            new List<string> { "3600", "3200" },
            65,
            95));
        Repository.CpuRepository.Create(new CPU(
            "Intel Core i7-12900k",
            "LGA1700",
            16,
            3200,
            false,
            new List<string> { "4800", "4400" },
            125,
            150));
    }

    private void CreateGPU()
    {
        Repository.GpuRepository.Create(new GPU(
            "Nvidia GeFroce RTX 3080",
            120,
            260,
            4,
            10_240,
            1_440,
            320));
        Repository.GpuRepository.Create(new GPU(
            "AMD Radeon RX 6700 XT",
            110,
            240,
            4,
            12_288,
            2_525,
            230));
        Repository.GpuRepository.Create(new GPU(
            "Nvidia GeFroce RTX 3060",
            80,
            170,
            3,
            6_144,
            1_320,
            115));
    }

    private void CreateHDD()
    {
        Repository.HddRepository.Create(new HDD(
            "Seagate Barracuda 4TB",
            4_000,
            7_200,
            80));
        Repository.HddRepository.Create(new HDD(
            "Western Digital 1TB",
            1_000,
            5_400,
            40));
        Repository.HddRepository.Create(new HDD(
            "Seagate IronWolf 10TB",
            10_000,
            7_200,
            90));
    }

    private void CreateMotherBoard()
    {
        Repository.MotherRepository.Create(new MotherBoard(
            "ASUS ROG Strix X570-E Gaming",
            "AM4",
            4,
            6,
            "X570",
            4,
            4,
            MotherBoardFormFactorType.ATX,
            Repository.BiosRepository.Read("ASUS BIOS") ?? throw new InvalidOperationException()));
        Repository.MotherRepository.Create(new MotherBoard(
            "Gigabyte B550I AORUS PRO AX",
            "LGA1700",
            1,
            4,
            "B550",
            4,
            2,
            MotherBoardFormFactorType.MiniATX,
            Repository.BiosRepository.Read("Gigabyte BIOS") ?? throw new InvalidOperationException()));
        Repository.MotherRepository.Create(new MotherBoard(
            "ASRock Rack EPYCD8-2T",
            "SP3",
            6,
            16,
            "AND SP3",
            4,
            16,
            MotherBoardFormFactorType.MiniATX,
            new BIOS("ASRock BIOS", BIOSType.Legacy, "1.5", new List<string> { "AMD EPYC" })));
    }

    private void CreatePowerBlock()
    {
        Repository.PowerRepository.Create(new PowerBlock(
            "EVGA 600W Bronze",
            600));
        Repository.PowerRepository.Create(new PowerBlock(
            "Corsair RM850x Gold",
            850));
        Repository.PowerRepository.Create(new PowerBlock(
            "Seasonic SS-300",
            300));
    }

    private void CreateRAM()
    {
        Repository.RamRepository.Create(new RAM(
            "Corsair Vengeance LPX 16GB",
            16,
            3200,
            135,
            RAMFormFactor.DIMM,
            4,
            2,
            null));
        Repository.RamRepository.Create(new RAM(
            "G.Skill Trident Z RGB 32GB",
            32,
            3600,
            135,
            RAMFormFactor.DIMM,
            4,
            3,
            new XMP("XMP 2", "2-2-2-2", 1, 10)));
        Repository.RamRepository.Create(new RAM(
            "Crucial 32GB ECC RDIMM",
            32,
            2933,
            120,
            RAMFormFactor.RDIMM,
            4,
            2,
            null));
    }

    private void CreateSSD()
    {
        Repository.SsdRepository.Create(new SSD(
            "Samsung 860 EVO 500GB",
            MemoryConnectionType.SATA,
            500,
            550,
            2));
        Repository.SsdRepository.Create(new SSD(
            "Western Digital Black 1TB",
            MemoryConnectionType.PCIE,
            1_000,
            7000,
            5));
        Repository.SsdRepository.Create(new SSD(
            "Crucial MX500 250GB",
            MemoryConnectionType.SATA,
            250,
            560,
            1));
    }

    private void CreateWiFiAdapter()
    {
        Repository.WifiRepository.Create(new WiFiAdapter(
            "Intel Wi-Fi 6 AX200",
            "Wi-Fi 6",
            true,
            3,
            2));
        Repository.WifiRepository.Create(new WiFiAdapter(
            "TP-Link Archer T9E",
            "Wi-Fi 5",
            false,
            2,
            3));
        Repository.WifiRepository.Create(new WiFiAdapter(
            "Asus PCE-AX58BT",
            "Wi-Fi 6E",
            true,
            4,
            4));
    }

    private void CreateXMP()
    {
        Repository.XmpRepository.Create(new XMP(
            "XMP Profile 1",
            "16-18-18-36",
            135,
            3200));
        Repository.XmpRepository.Create(new XMP(
            "XMP Profile 2",
            "15-16-16-35",
            140,
            3600));
        Repository.XmpRepository.Create(new XMP(
            "XMP Profile 3",
            "14-14-14-34",
            145,
            4000));
    }
}