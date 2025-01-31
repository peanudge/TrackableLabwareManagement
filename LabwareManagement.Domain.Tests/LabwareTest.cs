namespace LabwareManagement.Domain.Tests;

public class LabwareTests
{
    [Fact]
    public void ShouldCreateLabware()
    {
        // Arrange
        var id = new LabwareId(Guid.NewGuid());
        var ownerId = new UserId(Guid.NewGuid());

        // Act
        // Assert
        _ = new Labware(id, ownerId);
    }

    [Fact]
    public void ShouldThrowEmptyUserIdExceptionWhenCreateLabware()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new UserId(Guid.Empty);
        });
    }

    [Fact]
    public void ShouldThrowEmptyLabwareIdExceptionWhenCreateLabware()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new LabwareId(Guid.Empty);
        });
    }
}
