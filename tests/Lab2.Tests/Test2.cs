using Itmo.ObjectOrientedProgramming.Lab2.Common;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Builder;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;
public class Test2
{
    [Fact]
    public void SuccessfulWork()
    {
        var service = new Director();
        service.BuildComputer(
            "ASUS ROG Strix X570-E Gaming",
            "AMD Ryzen 7 5700G",
            null,
            "Liquid Cooler",
            "Corsair Vengeance LPX 16GB",
            null,
            "Nvidia GeFroce RTX 3080",
            "Samsung 860 EVO 500GB",
            null,
            "Versatile case",
            "Corsair RM850x Gold",
            null);
        Assert.Equal(Status.Successful, service.Builder.StatusOfBuilding);
    }

    [Fact]
    public void WarningWithPowerBlock()
    {
        var service = new Director();
        service.BuildComputer(
            "Gigabyte B550I AORUS PRO AX",
            "Intel Core i7-12900k",
            null,
            "Liquid Cooler",
            "G.Skill Trident Z RGB 32GB",
            null,
            "Nvidia GeFroce RTX 3080",
            null,
            "Seagate Barracuda 4TB",
            "Mid-Tower case",
            "Seasonic SS-300",
            "Intel Wi-Fi 6 AX200");
        Assert.Equal(Status.WarningWithPower, service.Builder.StatusOfBuilding);
    }

    [Fact]
    public void GuaranteeOffCooling()
    {
        var service = new Director();
        service.BuildComputer(
            "Gigabyte B550I AORUS PRO AX",
            "Intel Core i7-12900k",
            null,
            "Air Cooler",
            "G.Skill Trident Z RGB 32GB",
            null,
            "Nvidia GeFroce RTX 3060",
            null,
            "Seagate Barracuda 4TB",
            "Mid-Tower case",
            "Corsair RM850x Gold",
            "Intel Wi-Fi 6 AX200");
        Assert.Equal(Status.GuaranteeOff, service.Builder.StatusOfBuilding);
    }

    [Fact]
    public void WrongWork()
    {
        var service = new Director();
        service.BuildComputer(
            "ASUS ROG Strix X570-E Gaming",
            "AMD Ryzen 7 5700G",
            null,
            "Liquid Cooler",
            "Corsair Vengeance LPX 16GB",
            null,
            "Nvidia GeFroce RTX 3080",
            "Samsung 860 EVO 500GB",
            null,
            "Mini case",
            "Corsair RM850x Gold",
            null);
        Assert.Equal(Status.FailWithCase, service.Builder.StatusOfBuilding);
    }
}