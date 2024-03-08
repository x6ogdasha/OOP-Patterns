using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Prototypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

public class WifiAdapter : BaseComponent, IPrototype, IEquatable<WifiAdapter>
{
    public WifiAdapter(string name, string standardVersion, bool bluetoothModule, int versionOfPcie, int power)
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
        return new WifiAdapter(Name, StandardVersion, BluetoothModule, VersionOfPCIE, Power);
    }

    public IPrototype CloneWithNewStandard(string standard, string newName)
    {
        return new WifiAdapter(newName, standard, BluetoothModule, VersionOfPCIE, Power);
    }

    public IPrototype CloneWithNewBluetoothModule(bool module, string newName)
    {
        return new WifiAdapter(newName, StandardVersion, module, VersionOfPCIE, Power);
    }

    public bool Equals(WifiAdapter? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return StandardVersion == other.StandardVersion && BluetoothModule == other.BluetoothModule && VersionOfPCIE == other.VersionOfPCIE && Power == other.Power;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not WifiAdapter) return false;
        return Equals((WifiAdapter)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(StandardVersion, BluetoothModule, VersionOfPCIE, Power);
    }
}