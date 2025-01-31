using LabwareManagementa.Domain;

namespace LabwareManagement.Domain.Tests;

public class VolumeTest
{
    [Fact]
    public void ShouldEqualVolume()
    {
        var first = Volume.FromDouble(100);
        var second = Volume.FromDouble(100);
        Assert.Equal(first, second);
        Assert.True(Equals(first, second));
        Assert.True(first == second);
    }

    [Fact]
    public void ShouldSumOfVolumes()
    {
        var v1 = Volume.FromDouble(100);
        var v2 = Volume.FromDouble(200);
        var sum = Volume.FromDouble(300);
        Assert.Equal(sum, v1 + v2);
    }

    [Fact]
    public void SupportToCreateFromTextVolume()
    {
        var v1 = Volume.FromDouble(100);
        var v2 = Volume.FromString("100");
        Assert.Equal(v1, v2);
    }

    [Fact]
    public void ShouldEqual_ul_and_1000ml_LiquidVolume()
    {
        var liquid_1_ul = LiquidVolume.FromMicroliter(1000);
        var liquid_1_ml = LiquidVolume.FromMililiter(1);
        Assert.Equal(liquid_1_ml, liquid_1_ul);
    }

    [Fact]
    public void NotAllowSumBetweenDiffUnitCode()
    {
        var ulVolume = Volume.FromDouble(1000, "ul");
        var mlVolume = Volume.FromDouble(1, "ml");
        Assert.Throws<VolumeUnitMismatchException>(() =>
        {
            var sumVolume = ulVolume + mlVolume;
        });
    }

    [Fact]
    public void NotAllowSubstractBetweenDiffUnitCode()
    {
        var ulVolume = Volume.FromDouble(1000, "ul");
        var mlVolume = Volume.FromDouble(1, "ml");
        Assert.Throws<VolumeUnitMismatchException>(() =>
        {
            var subractedVolume = ulVolume - mlVolume;
        });
    }
}
