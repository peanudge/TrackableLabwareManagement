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
}
