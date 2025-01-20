# CQRS: Different way to express state transitions inside the domain.

The term originated from command-query seperation(CQS).

Object methods are seperated into two categories.

- Commands, which mutate the system (most often the object)state and return `Void`
- Queries, which return part of the system state and do not change the state of the system. This makes queries side effect free and idempotent.

CQRS(Command-query responsibility segregation) takes this principle outside of object.

Seperating commands and queries on the system level means that **any state transition for the system can be expressed by a command**, and such a command should be handled efficiently, optimized to perform the state transition.
