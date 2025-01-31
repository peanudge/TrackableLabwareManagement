using LabwareManagementa.Domain;

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

    public void SetBarcode(LabwareBarcode barcode) => _barcode = barcode;
    public void UpdateVolume(LiquidVolume volume) => _volume = volume;
    public void UpdateDescription(string description) => _description = description; // Bad smell: Just property setter

    private LabwareBarcode? _barcode = null; // TODO: Apply Null Object Pattern
    private LiquidVolume? _volume = null; // TODO: Apply Null Object Pattern
    private string _description = string.Empty;
}
