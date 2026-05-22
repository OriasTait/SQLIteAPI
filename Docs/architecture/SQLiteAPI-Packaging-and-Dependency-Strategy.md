# SQLiteAPI Packaging and Dependency Strategy

## 1. Purpose

This document defines the initial packaging and dependency strategy for
SQLiteAPI.

Its purpose is to establish how SQLiteAPI deliverables should be organized,
distributed, and consumed across supported target frameworks and operating
systems while keeping consumer setup as simple as practical.

This document must comply with:
- `/Docs/OS-Structure.md`
- `/Docs/AI-Guidelines.md`
- `/copilot-instructions.md`
- `/Docs/architecture/SQLiteAPI-Architecture-Blueprint.md`
- `/Docs/architecture/SQLiteAPI-Public-Contracts-Specification.md`
- `/Docs/architecture/SQLiteAPI-Framework-and-Platform-Support-Matrix.md`
- `/Docs/architecture/SQLiteAPI-Design-Policy-Statement.md`

This document defines packaging direction and dependency expectations. It does
not define detailed implementation code.

## 2. Packaging Goals

The packaging strategy must satisfy the following goals:
- Minimize the number of files consumers must include
- Keep the public API stable and easy to adopt
- Support both `.NET Framework 4.8` and `.NET 8`
- Support cross-platform deployment where approved
- Support Unity 6 as a primary consumer profile without making the API
  Unity-specific
- Avoid unnecessary exposure of SQLite provider internals
- Clearly document runtime dependencies
- Support open-source distribution and contributor understanding
- Enable incremental refinement without destabilizing consumer usage

## 3. Packaging Principles

SQLiteAPI packaging must follow these principles:
- Public Contracts should remain clearly separated from implementation
- Consumers should not be required to understand internal layer boundaries to
  use the library
- Provider/runtime dependencies must be documented explicitly
- Packaging should prefer predictability over “magic”
- Cross-platform support claims must reflect validated runtime behavior
- The simplest consumer experience should be preferred when multiple valid
  packaging options exist
- Unity 6 should be treated as a primary consumer profile in packaging guidance
  without redefining SQLiteAPI as a Unity-specific product

## 4. Scope of Deliverables

The initial SQLiteAPI rewrite is expected to produce deliverables in these
categories:
- Contracts assemblies
- Application assemblies
- Infrastructure assemblies
- Example applications
- Documentation artifacts

These deliverables will be built within the canonical enterprise structure and
distributed as reusable outputs.

## 5. Initial Assembly Strategy

The initial packaging approach should favor a small, understandable set of
assemblies.

### 5.1 Core Managed Assemblies

The initial consumer-facing assembly family should include:
- `SQLiteAPI.Contracts.dll`
- `SQLiteAPI.App.dll`
- `SQLiteAPI.Sqlite.dll`

Target framework distinctions should normally be handled by output folder
structure, package layout, or release metadata rather than being repeated in the
DLL file name.

For example:
- `bin/Release/net48/SQLiteAPI.Contracts.dll`
- `bin/Release/net8.0/SQLiteAPI.Contracts.dll`
- `bin/Release/net48/SQLiteAPI.App.dll`
- `bin/Release/net8.0/SQLiteAPI.App.dll`
- `bin/Release/net48/SQLiteAPI.Sqlite.dll`
- `bin/Release/net8.0/SQLiteAPI.Sqlite.dll`

### 5.2 Sample and Demonstration Outputs

Optional but recommended outputs include:
- `SQLiteAPI.ConsoleSample.exe`

Framework-specific distinction for sample outputs should normally be handled by
output folder structure rather than by embedding the target framework in the
file name.

These are not runtime dependencies for consumers. They exist only to demonstrate
usage.

## 6. Consumer Packaging Model

The packaging model should support a simple consumer experience.

### 6.1 Consumer Goal

The ideal consumer experience is:
1. Add the required SQLiteAPI assemblies
2. Add any required platform/runtime assets
3. Configure minimal startup wiring if needed
4. Call the public API

### 6.2 Initial Consumer Assembly Expectation

Consumers should ideally need only:
- Contracts assembly
- Application assembly
- SQLite infrastructure assembly

If runtime packaging requires native assets, those must be included with the
consumer application in a documented, predictable manner.

### 6.3 Unity 6 Packaging Position

Unity 6 must be treated as a primary consumer profile in packaging design.

This means packaging guidance must eventually define:
- how Unity consumers reference SQLiteAPI managed assemblies
- how provider-managed dependencies are delivered to Unity projects
- how native SQLite runtime assets are delivered per Unity target platform
- what limitations apply under IL2CPP/AOT compilation where relevant

The packaging strategy must support Unity strongly without redefining SQLiteAPI
as a Unity-specific product.

## 7. Definition of “Standalone”

SQLiteAPI is intended to be standalone in the sense that it should not require a
separate database server or external desktop tool.

For this project, “standalone” means:
- no separate database server installation is required
- no separate SQLite desktop application is required
- the consumer can distribute the required assemblies and assets with the
  application
- the consumer can call SQLiteAPI directly from its own code

For this project, “standalone” does not automatically mean:
- one universal DLL for every supported framework and platform
- zero supporting runtime assets
- zero packaging differences between targets

This distinction must be documented clearly for open-source consumers.

## 8. Managed vs Native Dependency Strategy

SQLite-based solutions may involve both managed and native dependencies.

### 8.1 Managed Dependencies

Managed dependencies include:
- SQLiteAPI assemblies
- any managed SQLite provider assemblies
- any managed support libraries required by the chosen implementation

### 8.2 Native Dependencies

Native dependencies may include:
- platform-specific SQLite runtime binaries
- platform-specific interop assets
- mobile/runtime-specific packaging assets

The final implementation must document native requirements clearly for each
supported platform.

## 9. Framework-Specific Packaging Position

## 9.1 .NET Framework 4.8

Packaging position:
- Windows-only in standard .NET runtime scenarios
- Managed outputs will be framework-specific
- Native runtime requirements must be documented if required by the chosen
  provider

Expected consumer experience:
- reference the `NET48` SQLiteAPI assemblies
- include any required Windows-native SQLite runtime assets
- deploy as part of the application output

## 9.2 .NET 8

Packaging position:
- modern target for Windows, macOS, Linux, and Android
- runtime packaging must account for platform-specific provider behavior
- platform support must be validated before being declared production-ready

Expected consumer experience:
- reference the `.NET 8` SQLiteAPI assemblies
- include any required target-specific runtime assets
- deploy according to the application’s runtime model

## 9.3 Unity 6 Consumer Position

Packaging position:
- Unity is a primary consumer profile
- managed assembly compatibility must be evaluated separately from standard
  runtime support statements
- packaging guidance must account for Unity project structure and target
  platform output behavior
- IL2CPP/AOT implications must be considered where relevant

Expected consumer experience:
- reference compatible SQLiteAPI managed assemblies from a Unity project
- include any required provider-managed and native runtime assets in a
  Unity-compatible way
- follow documented target-platform guidance for validated Unity scenarios

## 10. Platform-Specific Packaging Position

## 10.1 Windows

Expected packaging behavior:
- straightforward initial validation target
- should support the clearest first consumer experience
- runtime assets, if needed, should be distributed in the application output

## 10.2 macOS

Expected packaging behavior:
- supported under `.NET 8`
- targeted for Unity 6 consumption
- may require platform-specific native runtime assets
- distribution instructions must clearly identify any required files

## 10.3 Linux

Expected packaging behavior:
- supported under `.NET 8`
- targeted for Unity 6 consumption
- may require platform-specific native runtime assets
- documentation may need to note environment-specific deployment considerations

## 10.4 Android

Expected packaging behavior:
- supported under `.NET 8`, subject to provider/runtime validation
- targeted for Unity 6 consumption, subject to IL2CPP/AOT and packaging
  validation
- may require a different packaging approach than desktop/server targets
- documentation must clearly identify any Android-specific constraints

## 11. Packaging Layers vs Consumer Simplicity

The enterprise structure requires clean layer separation, but consumers should
not bear unnecessary complexity from that separation.

Therefore:
- internal project layering may remain separate
- released outputs may later be simplified if it can be done without violating
  architecture or destabilizing the public contract
- initial implementation should prioritize correctness and clarity first

A future facade or consolidated distribution approach may be considered
incrementally if it improves adoption.

## 12. Output Naming Strategy

Assembly naming should remain consistent and descriptive.

### 12.1 Naming Rules

Names should:
- begin with `SQLiteAPI`
- reflect their role clearly
- distinguish framework-specific outputs where needed
- avoid ambiguous platform naming unless platform-specific packaging is required

### 12.2 Initial Naming Direction

Recommended consumer-facing output names:
- `SQLiteAPI.Contracts.dll`
- `SQLiteAPI.App.dll`
- `SQLiteAPI.Sqlite.dll`

Recommended sample output name:
- `SQLiteAPI.ConsoleSample.exe`

Framework-specific distinctions should normally be represented by output
directories, package structure, or release metadata rather than repeated in file
names.

This keeps distribution artifacts shorter, clearer, and easier for consumers to
understand.

## 13. Dependency Documentation Requirements

Every release or documented build should identify:
- required managed assemblies
- optional managed assemblies
- required native assets
- target framework applicability
- operating system applicability
- any packaging limitations or exclusions

Documentation must answer these consumer questions clearly:
- Which DLLs do I need?
- Which files are optional?
- Does this work on my platform?
- Do I need native runtime files?
- Where do I place those files?
- What is the minimal setup to use SQLiteAPI?

## 14. Open-Source Distribution Expectations

Because SQLiteAPI is intended to be open source, packaging guidance must be easy
to understand for external users.

Open-source distribution should include:
- clear release notes
- a support matrix
- packaging instructions
- example applications
- quick-start usage examples
- explanation of framework and platform differences
- Unity-specific guidance where Unity scenarios are supported or targeted

No release should make broad portability claims without validated packaging
behavior.

## 15. Consumer Usage Patterns

The packaging strategy must support at least these usage patterns:
- reference from a Unity application
- reference from a desktop application
- reference from a console application
- reference from another class library
- reference from a web application
- reference from automation or tooling projects

The usage documentation should explain the minimal reference pattern for each.

## 16. Sample Application Packaging Expectations

Example applications should demonstrate the packaging model in a practical way.

Sample applications should show:
- which assemblies are referenced
- how configuration is handled
- how database paths are provided
- how lifecycle and query operations are invoked
- what runtime files must be present, if any

These examples should reduce ambiguity for consumers.

Unity-oriented examples should eventually demonstrate:
- managed assembly reference strategy
- target-platform packaging expectations
- any validated Unity-specific runtime notes

## 17. Release Packaging Options for Future Evaluation

The initial release should keep packaging simple and explicit. Future evaluation
may consider:
- consolidated distribution bundles
- packaging simplification for specific targets
- alternative delivery mechanisms
- stronger facade-based consumer entry points
- Unity-oriented distribution guidance where it improves adoption clarity

These possibilities must be evaluated incrementally and must not break the
approved contract surface.

## 18. Decision Record Expectations

Before implementation finalization, the selected packaging strategy should be
captured in a decision record that states:
- chosen provider approach
- managed dependency list
- native dependency list
- framework-specific differences
- platform-specific differences
- tradeoffs accepted for consumer simplicity

## 19. Initial Recommended Packaging Position

Until implementation validation proves otherwise, the default packaging position
should be:

1. Separate managed assemblies for:
   - Contracts
   - Application
   - SQLite infrastructure

2. Framework-specific outputs for:
   - `.NET Framework 4.8`
   - `.NET 8`

3. Explicit documentation of any native runtime requirements by platform and by
   validated Unity consumer scenario where applicable

4. Example applications demonstrating the minimal working consumer setup

This approach is the safest initial baseline because it is:
- architecture-compliant
- understandable
- incremental
- testable
- open-source friendly

## 20. Immediate Next Implementation Artifacts

After approval of this packaging strategy, the next recommended artifacts are:
1. Initial Contracts project file design
2. Initial interface and DTO files in `/SRC/Contracts`
3. A provider selection decision document
4. A sample application usage specification
5. A release/readme outline for open-source consumers

## 21. Final Principle

The packaging and dependency strategy for SQLiteAPI must remain:
- explicit
- minimal where practical
- well-documented
- framework-aware
- platform-aware
- consumer-friendly

The goal is not to hide reality. The goal is to make SQLiteAPI as easy to adopt
as possible while documenting the true runtime requirements clearly.
