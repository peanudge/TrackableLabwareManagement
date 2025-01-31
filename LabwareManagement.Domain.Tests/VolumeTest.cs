using LabwareManagementa.Domain;

namespace LabwareManagement.Domain.Tests;

public class VolumeTest
{
    [Fact]
    public void ShouldEqualVolume()
    {
        var first = new Volume(100);
        var second = new Volume(100);
        Assert.Equal(first, second);
        Assert.True(Equals(first, second));
        Assert.True(first == second);
    }

    [Fact]
    public void SumOfVolumes()
    {
        var v1 = new Volume(100);
        var v2 = new Volume(200);
        var sum = new Volume(300);
        Assert.Equal(sum, v1 + v2);
    }
}
