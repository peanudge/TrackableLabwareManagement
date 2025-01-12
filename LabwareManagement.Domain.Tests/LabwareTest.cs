namespace LabwareManagement.Domain.Tests;

public class LabwareTests
{
    [Fact]
    public void ExampleTest()
    {
        var testBarcode = "TEST_BARCODE";
        var labware = new Labware(testBarcode);
        Assert.Equal($"Labware(barcode: {testBarcode})", labware.ToString());
    }
}
