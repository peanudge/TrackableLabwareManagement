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


    private Guid? _ownerId = null;
    private string _barcode = string.Empty;
    private string _description = string.Empty;
    private double _volume = 0.0;


}
