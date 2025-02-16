# Labware as Entity model

Entities represent unique objects of the same type.

`Labware` term is frequently referred by research (Main User. Bio-Researcher)

Labwares are uniqued during experiment. these objects will have seperate identities.

# Identities

In real life, many objects are already identified. The most common identity is an item serial number.

Complex object like smartphone, Tv sets, computers and cars have unique identifiers that help manufacturers to know in what configuration these objects were produced. They can provide better support.

However! when we talk about our system, most of time we need to use our own identity.

The only important rule is that all entities need to be uniquely identified.

## Pitfall: DB key as Identities

Probably the most frequently used method to get unique identities today (later referenced as IDs) is to use unique database keys.

Such a system will not work without persisting stuff to a particular database.

The most significant disadvantage comes from the ID source - the database must be present to get such an identity, even if later in the flow, the system will decide not to accept the object and drop it instead, so it never gets persisted. => Strong Coupling with infrastructure!!

## Solution: Generated Unique IDs - GUID, UUID

We will use generated unique IDs. Because we would prefer not to use any infrastructure to create our IDs.

We will use one reliable method and identity type -- a globally unique identifier (GUID), more commonly known as a universally unique identifier (UUID).

Such an ID can be generated using **the current time and some information about the computer, where it is produced.**

When using GUIDs, we can generate identities for objects before touching any infrastructure! and therefore create references to an object that only exist in memory.

# Shall try to encapsulate as much as we can

Keep our internals safe and preferably invisible to outside world.

# Behavior First Design

Remember, we need to design behavior-first. The only reason for us to add those `private` fields to the entity was actually to support the behavior.

Encapsulation being enforced, we shall not allow manipulating the entity state by changing property values from outside the entity. This will lead us to the dusty land of CRUD.

```cs
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
```

Above code represents just property setters. (method's name is just only ubiqutous language)

Find out how methods that express behavior can become more useful.

# Ensure Correctness

Checking entity constructor parameter to be valid to ensure the newly created entity object is also correct.

The ultimate control is always performed inside the domain model itself, since it shall never come to an invalid state.

```cs
public class Labware {
    public Labware(Guid id, string barcode)
    {
        if (id == default)
        {
            throw new ArgumentException("Identity must be specified", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(barcode))
        {
            throw new ArgumentException("Barcode must be specified", nameof(barcode));
        }

        Id = id;
        _barcode = barcode;
    }
}
```

Adding more parameters to the entity constructor, and **the constructor itself grows** since we add more checks for these parameters.

This approach is not wrong but is also not ideal.

Instead,

We can check the validity of such values, even before reaching the entity constructor, using **value objects.**

# Value Object

It is most popular in DDD community. It probably happened due to such characteristics of value objects as **expressiveness and strong encapsulation.**

Fundamentally, value objects allow declaring entity properties with explicit types that use Ubiquitous Language.

It is a perfect example about `making Implicit to Explicity`.

```csharp
public class Labware {
    private LabwareId Id {get;}
    private UserId _ownerId;
    public Labware(LabwareId id, UserId ownerId)
    {
        Id = id;
        _ownerId = ownerId;
    }
}


var item = new Labware(
    new LabwareId(Guid.NewGuid()),
    new UserId(Guid.NewGuid())
    );
```

Strongly typed parameters of value object types force the compiler to engage type checking.
if we messed up arguments, the code won't compile.

But, value object aren't just value wrapper types around primitive types.

# Domain Service

We can go for a dependency on some external service.
but, we know that **domain models should not have external dependencies.**

We should not put any implementation details inside domain model.

It means that the only thing we are going to have inside the domain project is **domain service interface**.

As example code, i will introduce domain service to check duplication of barcode. called `IBarcodeLookup`.

```csharp
public interface IBarcodeLookup {
    public bool FindLabwareWithBarcode(LabwareBarcode barcode);
}
```
