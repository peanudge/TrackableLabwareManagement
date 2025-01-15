namespace LabwareManagement.Domain.Tests;

public class LabwareTests
{
    [Fact]
    public void Should_Be_Unused_When_Initial()
    {
        var unusedLabware = new Labware();
        Assert.Equal(LabwareUseStatus.Unused, unusedLabware.UseStatus);
    }

    [Fact]
    public void Should_Be_InUse_After_StartToUse()
    {
        var labware = new Labware();
        labware.StartToUse();
        Assert.Equal(LabwareUseStatus.InUse, labware.UseStatus);
    }
}
