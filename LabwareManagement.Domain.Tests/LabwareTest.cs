namespace LabwareManagement.Domain.Tests;

public class LabwareTests
{
    [Fact]
    public void ShouldCreateLabware()
    {
        // Arrange
        var id = Guid.NewGuid();
        var barcode = "1234567890";

        // Act
        // Assert
        _ = new Labware(id, barcode);
    }

    [Fact]
    public void ShouldThrowBarcodeExceptionWhenCreateLabware()
    {
        // Arrange
        var id = Guid.NewGuid();
        var barcode = string.Empty;

        // Act
        // Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var labware = new Labware(id, barcode);
        });
    }

    [Fact]
    public void ShouldThrowIdExceptionWhenCreateLabware()
    {
        // Arrange
        var id = Guid.Empty;
        var barcode = string.Empty;

        // Act
        // Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var labware = new Labware(id, barcode);
        });
    }
}
