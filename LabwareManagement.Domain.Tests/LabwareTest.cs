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

    private class FakeBarcodeLookup : IBarcodeLookup
    {
        public readonly IEnumerable<BarcodeDetection> _barcodes = new List<BarcodeDetection>
        {
            new BarcodeDetection(){ InUsed = true, Barcode = "1234567890"  },
        };

        public BarcodeDetection FindBarcode(string barcode)
        {
            var barcodeDetection = _barcodes.FirstOrDefault(b => b.Barcode == barcode);
            return barcodeDetection ?? BarcodeDetection.NotFound;
        }
    }

    [Fact]
    public void ShouldNotAllowToUpdateDuplicatedBarcode()
    {
        // Arrange
        var barcodeLookup = new FakeBarcodeLookup();

        // Act
        var labware = new Labware(
            id: new LabwareId(Guid.NewGuid()),
            ownerId: new UserId(Guid.NewGuid()));

        var barcode = LabwareBarcode.FromString("1234567890");

        // Assert
        Assert.Throws<Labware.BarcodeDuplicationException>(() => labware.SetBarcode(barcode, barcodeLookup));
    }
}
