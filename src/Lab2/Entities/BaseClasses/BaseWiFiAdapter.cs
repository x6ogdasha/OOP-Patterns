namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class BaseWiFiAdapter
{
    public BaseWiFiAdapter(string standardVersion, bool bluetoothModule, int versionOfPcie, int power)
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
}