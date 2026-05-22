# SQLiteAPI Architecture Blueprint

## 1. Purpose

This document defines the initial architectural blueprint for the rewrite of the
SQLiteAPI solution within the canonical enterprise repository model.

This blueprint is intended to standardize how SQLite is accessed across future
solutions that consume SQLiteAPI deliverables.

The architecture defined here must comply with:
- `/Docs/OS-Structure.md`
- `/Docs/AI-Guidelines.md`
- `/copilot-instructions.md`

This document does not redefine repository structure. It only describes how the
SQLiteAPI solution should be implemented within the approved structure.

## 2. Scope

SQLiteAPI is intended to provide a reusable, open-source, SQLite-focused API for
use by other solutions, including:
- Unity applications
- Desktop applications
- Console applications
- Class libraries
- Web applications
- Service and automation solutions
- Other reusable components

The primary design goal is to provide a stable and standardized interface for
common SQLite operations while minimizing the number of DLLs consumers must
reference.

SQLiteAPI must be designed incrementally and delivered as a set of reusable
assemblies built inside the existing enterprise structure.

## 3. Supported Frameworks and Platforms

### 3.1 Target Frameworks

The initial release should target:
- .NET Framework 4.8
- .NET 8.0

.NET 8.0 is selected instead of .NET 9 because .NET 8 is the more stable,
long-term support target.

### 3.2 Supported Platforms

The solution must account for the following operating systems:
- Windows
- macOS
- Linux
- Android

### 3.3 Runtime and Consumer Clarification

Support must distinguish between:
- standard .NET runtime support
- Unity consumer compatibility
- provider/runtime packaging validation

### 3.4 Standard .NET Runtime Position

For standard .NET consumers:
- `.NET Framework 4.8` is supported on Windows only
- `.NET 8` is the primary modern cross-platform target

This reflects the standard Microsoft .NET runtime position for general-purpose
consumer applications and libraries.

### 3.5 Unity 6 Consumer Clarification

Unity 6 consumers must be treated as a distinct compatibility scenario.

Unity's `NET_Unity_4_8` API compatibility level targets the union of the
`.NET Framework 4.8` and `.NET Standard 2.1` API surface. This means a managed
assembly that is compatible with Unity's scripting environment may be consumable
by Unity projects across multiple platforms, even though the standard
`.NET Framework 4.8` runtime itself is Windows-only.

Therefore, the statement that `.NET Framework 4.8` is Windows-only applies to
standard .NET runtime usage, but must not be interpreted to mean that Unity 6
projects are restricted to Windows when consuming compatible assemblies.

### 3.6 Unity Platform Validation Requirement

Unity cross-platform support does not automatically guarantee that every
SQLiteAPI assembly, provider choice, native SQLite runtime dependency, or
execution path will behave identically on all Unity targets.

Unity commonly uses IL2CPP for platform builds, which converts managed IL to C++
and compiles it into platform-specific native code as part of an ahead-of-time
workflow. This can affect packaging, native interop, reflection behavior,
generic code paths, and provider/runtime compatibility.

For that reason, Unity support for Windows, macOS, Linux, and Android must be
treated as validated support rather than assumed support.

### 3.7 Architectural Implication

Because Unity 6 is an intended consumer, SQLiteAPI must be designed so that:
- public Contracts remain provider-agnostic
- Unity-compatible managed assemblies are possible where practical
- provider and native runtime dependencies remain isolated to Infrastructure
- platform support claims are based on tested runtime behavior
- Unity-specific support notes are documented separately from standard .NET
  runtime statements

## 4. Architectural Goals

SQLiteAPI should be designed to satisfy the following goals:
- Standardize SQLite usage across solutions
- Provide a stable API boundary for consumers
- Minimize consumer complexity
- Avoid forcing consumers to understand SQLite provider internals
- Support incremental extension of functionality over time
- Preserve enterprise layer separation
- Remain suitable for open-source distribution
- Enable testing, documentation, and example-based adoption

### 4.1 Design Policy Position

SQLiteAPI must remain generic in its public contract design and must not be
shaped as a Unity-specific API.

However, Unity 6 is a primary consumer profile for this solution and must be
treated as a first-class concern in:
- provider selection
- packaging strategy
- documentation planning
- validation planning
- sample and adoption guidance

This means SQLiteAPI should remain platform-equal in architectural intent while
allowing validation maturity to progress in practical phases.

## 5. Canonical Repository Placement

All work must remain within the canonical enterprise structure.

The SQLiteAPI rewrite must use the following approved locations:
- `/SRC/Domain`
- `/SRC/Contracts`
- `/SRC/Application`
- `/SRC/Infrastructure`
- `/SRC/Presentation`
- `/Tests`
- `/Docs`
- `/UIs`

No new top-level directories may be introduced.

## 6. Layer Responsibilities

### 6.1 `/SRC/Domain`

Purpose:
- Define domain concepts related to SQLite operations only where domain-level
  abstractions are required

Expected contents:
- Enums representing operation categories or statuses
- Value objects used across layers when they are domain-safe
- Domain interfaces if a pure abstraction is required

Constraints:
- No provider-specific code
- No direct SQL execution logic
- No platform-specific logic
- No HTTP or UI concerns

Note:
For this solution, the Domain layer is expected to remain intentionally small,
as most functionality is technical and integration-oriented rather than rich
business-domain modeling.

### 6.2 `/SRC/Contracts`

Purpose:
- Provide the stable public interface boundary for consumers and internal
  layering

Expected contents:
- Public service interfaces
- Request and response models
- Result abstractions
- Status models
- Exception contracts where appropriate
- Serialization-safe DTOs

Initial interface areas should include:
- Database lifecycle operations
- Database status inspection
- Database maintenance operations
- SQL command execution operations
- Query result abstractions

This layer must remain implementation-free and stable.

### 6.3 `/SRC/Application`

Purpose:
- Orchestrate use cases and enforce workflow rules

Expected contents:
- Service implementations for Contracts interfaces
- Validation logic
- Operation coordination
- Transaction orchestration policies
- Mapping between infrastructure results and contract models

Constraints:
- No direct UI concerns
- No raw provider-specific logic beyond delegated infrastructure access
- No direct schema ownership

### 6.4 `/SRC/Infrastructure`

Purpose:
- Contain the actual SQLite provider implementation details

Expected contents:
- Connection management
- Database file operations
- SQLite command execution
- Maintenance command handling
- Provider-specific adapters
- Mapping from raw provider results into internal representations

Constraints:
- No business-rule ownership
- No UI logic
- No repository structure changes

This layer is expected to contain the primary implementation complexity.

### 6.5 `/SRC/Presentation`

Purpose:
- Provide delivery-oriented entry points and demonstration surfaces

Expected contents:
- Console-based sample host if placed under source delivery projects
- Thin facade or composition root projects if needed
- Dependency registration examples

Note:
This repository uses `/SRC/Presentation` as the canonical physical location.
No `/SRC/Api` folder may be introduced unless the governing structure document
is explicitly changed.

### 6.6 `/UIs`

Purpose:
- Provide consumer-facing example applications

Expected contents:
- Example console applications
- Usage demonstrations for each supported capability
- Minimal sample projects showing reference patterns

### 6.7 `/Tests`

Purpose:
- Validate correctness and compatibility

Expected contents:
- Unit tests for Application behavior
- Integration tests for SQLite execution and file handling
- Regression tests for result shaping
- Framework-specific validation where practical

## 7. Proposed Deliverables

The final implementation should produce reusable assemblies whose names begin
with `SQLiteAPI`.

The exact naming may be refined during implementation, but the initial target
family is:
- `SQLiteAPI.Contracts`
- `SQLiteAPI.Application`
- `SQLiteAPI.Infrastructure.SQLite`

Framework-specific build outputs may use names such as:
- `SQLiteAPI.Contracts_NET48.dll`
- `SQLiteAPI.Contracts_NET8.dll`
- `SQLiteAPI.Application_NET48.dll`
- `SQLiteAPI.Application_NET8.dll`
- `SQLiteAPI.Infrastructure.SQLite_NET48.dll`
- `SQLiteAPI.Infrastructure.SQLite_NET8.dll`

A sample application may also be produced, for example:
- `SQLiteAPI.ConsoleSample_NET48.exe`
- `SQLiteAPI.ConsoleSample_NET8.exe`

## 8. Packaging Strategy

The packaging strategy should prioritize ease of consumption.

### 8.1 Packaging Goals

The packaging approach should:
- Minimize the number of assemblies consumers must manually include
- Keep Contracts stable
- Keep implementation replaceable if needed later
- Support framework-specific builds cleanly
- Be suitable for open-source distribution

### 8.2 Initial Recommendation

The implementation should initially favor a small number of assemblies:
- One Contracts assembly per framework family
- One Application assembly per framework family
- One SQLite Infrastructure assembly per framework family

If a simpler facade can be introduced later without violating layering, that may
be considered as an incremental enhancement.

### 8.3 Provider and Native Runtime Considerations

SQLite commonly relies on provider/runtime assets that may vary by target
framework and operating system.

Therefore, the final packaging design must document:
- Required managed assemblies
- Any required native runtime assets
- Platform-specific limitations
- Distribution expectations for Windows, macOS, Linux, and Android

The implementation should aim to make consumer setup as simple as possible,
while accurately documenting unavoidable runtime dependencies.

## 9. Public Capability Areas

The initial public surface should cover the following functional groups.

### 9.1 Database Lifecycle

Required operations:
- Create a database
- Delete a database
- Check whether a database exists
- Validate that a database can be opened
- Retrieve basic database metadata when available

### 9.2 Database Status

Required operations:
- Determine whether the database file exists
- Determine whether the database file is accessible
- Determine whether the database appears locked or unavailable
- Check integrity status
- Retrieve basic environment/readiness information

### 9.3 Database Maintenance

Required operations:
- Vacuum database
- Analyze database
- Reindex database where applicable
- Run integrity checks
- Support additional maintenance routines incrementally

### 9.4 SQL Execution

Required operations:
- Execute a non-query SQL command
- Execute parameterized SQL commands
- Execute a scalar query
- Execute a query returning one result set
- Execute a query returning multiple result sets when supported by the
  execution strategy
- Support transaction-aware execution patterns

### 9.5 Query Results

Results returned to callers must be easy to consume and consistent.

The result model should support:
- Execution success/failure status
- Affected row count where relevant
- Scalar values where relevant
- One or more tabular result sets
- Column metadata where appropriate
- Error messages and diagnostic context

## 10. Query Result Strategy

A standardized result model is required so callers do not depend directly on
provider-specific objects.

### 10.1 Design Goals

The query result model should:
- Be easy to consume from multiple application types
- Work for both .NET Framework 4.8 and .NET 8
- Avoid forcing callers to bind directly to provider-specific types
- Support both simple and advanced usage scenarios

### 10.2 Initial Result Model Recommendation

The initial design should define contract models that represent:
- A command result
- A scalar result
- A query result
- A query result set
- A row abstraction
- A column abstraction

Where appropriate, compatibility helpers may later be added for `DataTable` or
`DataSet` conversion, especially for legacy consumers.

## 11. Error Handling and Diagnostics

SQLiteAPI should provide predictable and well-documented error behavior.

### 11.1 Error Handling Goals

The API should:
- Return structured operation results where appropriate
- Preserve useful diagnostic information
- Avoid leaking unnecessary provider internals into the public contract
- Distinguish validation failures from execution failures
- Distinguish file-system issues from SQL execution issues where possible

### 11.2 Logging and Diagnostics

Diagnostic hooks may be introduced incrementally, but the initial implementation
must at minimum provide:
- Human-readable error messages
- Operation status indicators
- Exception propagation rules documented for consumers

## 12. Transactions and Concurrency

The design must account for transaction and file-locking behavior.

Initial design considerations:
- Non-query execution should support transaction-aware workflows
- Maintenance operations should document locking implications
- Status checks should attempt to identify inaccessible or locked databases
- Concurrency expectations must be documented clearly for consumers

## 13. Security and Safety

The implementation should promote safe database usage.

Required design principles:
- Prefer parameterized command execution
- Avoid encouraging unsafe SQL construction patterns
- Validate file path inputs where practical
- Document any destructive operations explicitly
- Clearly identify maintenance operations that may be expensive or blocking

## 14. Open-Source Documentation Requirements

Because SQLiteAPI is intended to be open source, documentation is a first-class
deliverable.

The documentation set should include:
- Overview of the solution purpose
- Supported framework and platform matrix
- Installation and reference instructions
- Quick-start examples
- Capability-by-capability usage guidance
- Limitations and runtime notes
- Versioning and compatibility notes

## 15. Example Applications

At least one example application should be created to demonstrate usage.

The preferred initial example is a console application that demonstrates:
- Creating a database
- Checking database status
- Running a non-query command
- Running a query and reading results
- Performing maintenance
- Deleting a database

If practical, example applications may be produced for both `.NET Framework 4.8`
and `.NET 8`.

### 15.1 Unity Consumer Examples

Because Unity 6 is a primary consumer profile, the documentation and example
strategy should eventually include at least one Unity-oriented integration
example.

This does not require the core API to become Unity-specific. It means the
project should demonstrate how a Unity consumer references the managed
assemblies, handles runtime dependencies, and uses the public Contracts safely
within Unity-supported execution models.

## 16. Phased Implementation Roadmap

The rewrite should proceed incrementally.

### Phase 1 - Repository Alignment and Design
- Confirm enterprise-compliant structure in the repository
- Create and approve architecture documentation
- Define naming and project boundaries
- Define the public contract surface

### Phase 2 - Contracts
- Implement the core Contracts models and interfaces
- Define operation result models
- Define query result models
- Define status and maintenance option models

### Phase 3 - Application Layer
- Implement orchestration services
- Implement validation and operation coordination
- Define exception and result translation rules

### Phase 4 - Infrastructure Layer
- Implement SQLite provider integrations
- Implement lifecycle operations
- Implement status and maintenance operations
- Implement command/query execution

### Phase 5 - Samples and Tests
- Add sample console applications
- Add unit and integration tests
- Add consumer usage documentation

### Phase 6 - Packaging and Release Readiness
- Finalize assembly naming
- Finalize runtime dependency documentation
- Validate framework-specific outputs
- Prepare open-source release documentation

## 17. Immediate Next Design Artifacts

After approval of this blueprint, the next recommended design artifacts are:
1. A public contracts specification for the initial API surface
2. A framework and platform support matrix document
3. A packaging and dependency strategy document
4. A sample usage specification for the console example app

## 18. Final Principle

SQLiteAPI must remain:
- Incremental
- Layer-compliant
- Provider-aware
- Consumer-friendly
- Open-source ready

The solution must standardize SQLite usage without violating the enterprise
structure or introducing architectural drift.
