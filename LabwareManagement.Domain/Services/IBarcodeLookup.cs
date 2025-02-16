namespace LabwareManagement.Domain;

public interface IBarcodeLookup
{
	BarcodeDetection FindBarcode(string barcode);
};

public record class BarcodeDetection
{
	public string? Barcode { get; set; }
	public bool InUsed { get; init; }
	public static BarcodeDetection NotFound = new BarcodeDetection() { InUsed = false };
}

