using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;

public class RepositoryContext
{
    public RepositoryContext()
    {
        BiosRepository = new Repository<BIOS>();
        CaseRepository = new Repository<ComputerCase>();
        CoolingRepository = new Repository<CoolingSystem>();
        CpuRepository = new Repository<CPU>();
        GpuRepository = new Repository<GPU>();
        HddRepository = new Repository<HDD>();
        MotherRepository = new Repository<MotherBoard>();
        PowerRepository = new Repository<PowerBlock>();
        RamRepository = new Repository<RAM>();
        SsdRepository = new Repository<SSD>();
        WifiRepository = new Repository<WiFiAdapter>();
        XmpRepository = new Repository<XMP>();
    }

    public Repository<BIOS> BiosRepository { get; set; }
    public Repository<ComputerCase> CaseRepository { get; set; }
    public Repository<CoolingSystem> CoolingRepository { get; set; }
    public Repository<CPU> CpuRepository { get; set; }
    public Repository<GPU> GpuRepository { get; set; }
    public Repository<HDD> HddRepository { get; set; }
    public Repository<MotherBoard> MotherRepository { get; set; }
    public Repository<PowerBlock> PowerRepository { get; set; }
    public Repository<RAM> RamRepository { get; set; }
    public Repository<SSD> SsdRepository { get; set; }
    public Repository<WiFiAdapter> WifiRepository { get; set; }
    public Repository<XMP> XmpRepository { get; set; }
}