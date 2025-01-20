namespace LabwareManagement.Domain;

public enum LabwareUseStatus
{
    Unused = 1,
    InUse = 2,
}

public class Labware
{
    private LabwareUseStatus _status;

    public LabwareUseStatus UseStatus => _status;

    public Labware()
    {
        _status = LabwareUseStatus.Unused;
    }

    public void StartToUse()
    {
        _status = LabwareUseStatus.InUse;
    }
}
