using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class WiFiAdapter : BaseComponent, IPrototype
{
    public WiFiAdapter(string name, string standardVersion, bool bluetoothModule, int versionOfPcie, int power)
    {
        Name = name;
        StandardVersion = standardVersion;
        BluetoothModule = bluetoothModule;
        VersionOfPCIE = versionOfPcie;
        Power = power;
    }

    public string StandardVersion { get; protected set; }
    public bool BluetoothModule { get; protected set; }
    public int VersionOfPCIE { get; protected set; }
    public int Power { get; protected set; }
    public IPrototype Clone()
    {
        return new WiFiAdapter(Name, StandardVersion, BluetoothModule, VersionOfPCIE, Power);
    }

    public IPrototype CloneWithNewStandard(string standard, string newName)
    {
        return new WiFiAdapter(newName, standard, BluetoothModule, VersionOfPCIE, Power);
    }

    public IPrototype CloneWithNewBluetoothModule(bool module, string newName)
    {
        return new WiFiAdapter(newName, StandardVersion, module, VersionOfPCIE, Power);
    }
}