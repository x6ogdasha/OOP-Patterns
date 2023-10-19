using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class WiFiAdapter : Prototype
{
    public WiFiAdapter(string standardVersion, bool bluetoothModule, int versionOfPcie, int power)
    {
        StandardVersion = standardVersion;
        BluetoothModule = bluetoothModule;
        VersionOfPCIE = versionOfPcie;
        Power = power;
    }

    public string StandardVersion { get; protected set; }
    public bool BluetoothModule { get; protected set; }
    public int VersionOfPCIE { get; protected set; }
    public int Power { get; protected set; }
    public override Prototype Clone()
    {
        return new WiFiAdapter(StandardVersion, BluetoothModule, VersionOfPCIE, Power);
    }

    public Prototype CloneWithNewStandard(string standard)
    {
        return new WiFiAdapter(standard, BluetoothModule, VersionOfPCIE, Power);
    }

    public Prototype CloneWithNewBluetoothModule(bool module)
    {
        return new WiFiAdapter(StandardVersion, module, VersionOfPCIE, Power);
    }
}