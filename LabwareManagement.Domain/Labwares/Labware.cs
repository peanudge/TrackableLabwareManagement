namespace LabwareManagement.Domain;

public class Labware
{
    private string Barcode { get; init; }

    public Labware(string barcode = "")
    {
        if (barcode is null)
        {
            throw new ArgumentNullException(nameof(barcode));
        }
        Barcode = barcode;
    }

    public new string ToString()
    {
        return $"Labware(barcode: {Barcode})";
    }
}
