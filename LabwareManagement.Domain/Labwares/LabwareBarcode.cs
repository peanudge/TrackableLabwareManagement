namespace LabwareManagement.Domain;

public record class LabwareBarcode
{
    // Factory Methods
    public static LabwareBarcode FromString(string text) => new LabwareBarcode(text);
    public static LabwareBarcode FromGuid(Guid guid) => new LabwareBarcode(guid.ToString());

    public string Value { get; }

    private LabwareBarcode(string value)
    {
        if (value.Length > 100)
        {
            throw new ArgumentException("Barcode cannot be longer that 100 character.", nameof(value));
        }
        Value = value;
    }
}
