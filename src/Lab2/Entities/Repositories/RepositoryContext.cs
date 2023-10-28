using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;

public class RepositoryContext
{
    public RepositoryContext()
    {
        BiosRepository = new Repository<Bios>();
        CaseRepository = new Repository<ComputerCase>();
        CoolingRepository = new Repository<CoolingSystem>();
        CpuRepository = new Repository<Cpu>();
        GpuRepository = new Repository<Gpu>();
        HddRepository = new Repository<Hdd>();
        MotherRepository = new Repository<MotherBoard>();
        PowerRepository = new Repository<PowerBlock>();
        RamRepository = new Repository<Ram>();
        SsdRepository = new Repository<Ssd>();
        WifiRepository = new Repository<WifiAdapter>();
        XmpRepository = new Repository<Xmp>();
    }

    public Repository<Bios> BiosRepository { get; set; }
    public Repository<ComputerCase> CaseRepository { get; set; }
    public Repository<CoolingSystem> CoolingRepository { get; set; }
    public Repository<Cpu> CpuRepository { get; set; }
    public Repository<Gpu> GpuRepository { get; set; }
    public Repository<Hdd> HddRepository { get; set; }
    public Repository<MotherBoard> MotherRepository { get; set; }
    public Repository<PowerBlock> PowerRepository { get; set; }
    public Repository<Ram> RamRepository { get; set; }
    public Repository<Ssd> SsdRepository { get; set; }
    public Repository<WifiAdapter> WifiRepository { get; set; }
    public Repository<Xmp> XmpRepository { get; set; }
}