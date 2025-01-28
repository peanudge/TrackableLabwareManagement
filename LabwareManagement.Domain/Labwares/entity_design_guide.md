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

Ffind out how methods that express behavior can become more useful.
