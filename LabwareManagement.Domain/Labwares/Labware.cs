namespace LabwareManagement.Domain;

public class Labware
{
    public Guid Id { get; private set; }
    private string _barcode = string.Empty;
    private string _description = string.Empty;
    private double _volume = 0.0;
}
