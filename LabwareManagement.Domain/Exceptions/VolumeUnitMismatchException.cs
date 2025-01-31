namespace LabwareManagement.Domain;


// INFO: Domain Specific Exception!
public class VolumeUnitMismatchException : Exception
{
    public VolumeUnitMismatchException(string message) : base(message)
    {

    }
}
