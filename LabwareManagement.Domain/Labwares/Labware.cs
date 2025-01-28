namespace LabwareManagement.Domain;

public class Labware
{
    public Guid Id { get; }

    public Labware(Guid id)
    {
        if (id == default)
        {
            throw new ArgumentException("Identity must be specified", nameof(id));
        }
        Id = id;
    }

    public void SetBarcode(string barcode) => _barcode = barcode; // Bad smell: Just property setter
    public void UpdateDescription(string description) => _description = description; // Bad smell: Just property setter
    public void UpdateVolume(double volume) => _volume = volume; // Bad smell: Just property setter

    private string _barcode = string.Empty;
    private string _description = string.Empty;
    private double _volume = 0.0;
}
