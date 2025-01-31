namespace LabwareManagement.Domain;

public class Labware
{
    private LabwareId Id { get; }
    private UserId _ownerId;

    public Labware(LabwareId id, UserId ownerId)
    {
        Id = id;
        _ownerId = ownerId;
    }

    public void SetBarcode(string barcode) => _barcode = barcode; // Bad smell: Just property setter
    public void UpdateDescription(string description) => _description = description; // Bad smell: Just property setter
    public void UpdateVolume(double volume) => _volume = volume; // Bad smell: Just property setter

    private string _barcode = string.Empty;
    private string _description = string.Empty;
    private double _volume = 0.0;
}
