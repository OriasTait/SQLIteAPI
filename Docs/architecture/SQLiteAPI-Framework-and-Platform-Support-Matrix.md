# SQLiteAPI Framework and Platform Support Matrix

## 1. Purpose

This document defines the supported framework and platform matrix for SQLiteAPI.

Its purpose is to establish a clear compatibility baseline for:
- runtime targeting
- operating system support
- packaging expectations
- consumer adoption guidance
- implementation constraints

This document must comply with:
- `/Docs/OS-Structure.md`
- `/Docs/AI-Guidelines.md`
- `/copilot-instructions.md`
- `/Docs/architecture/SQLiteAPI-Architecture-Blueprint.md`
- `/Docs/architecture/SQLiteAPI-Public-Contracts-Specification.md`

This document is the support baseline for design and implementation decisions.
It does not define implementation details.

## 2. Design Goals

The framework and platform support strategy must satisfy the following goals:
- Support legacy Windows consumers through .NET Framework 4.8
- Support modern cross-platform consumers through .NET 8
- Keep the public API as consistent as possible across supported targets
- Document unavoidable platform/runtime differences clearly
- Minimize consumer confusion regarding DLL usage and deployment expectations
- Support open-source adoption with predictable compatibility guidance

## 3. Approved Initial Target Frameworks

SQLiteAPI should initially target:
- .NET Framework 4.8
- .NET 8.0

### 3.1 Why .NET Framework 4.8

.NET Framework 4.8 is included to support existing Windows-based enterprise and
legacy solutions that still require traditional .NET Framework compatibility.

### 3.2 Why .NET 8.0

.NET 8.0 is included as the current long-term support target and the preferred
modern runtime for cross-platform usage.

### 3.3 Why Not .NET 9 Initially

.NET 9 may be evaluated later, but the initial standard should prioritize
stability and long-term support. Therefore, .NET 8.0 is the approved modern
target for the first rewrite.

## 4. Operating System Support Overview

SQLiteAPI is intended to support the following operating systems:
- Windows
- macOS
- Linux
- Android

However, support varies by target framework.

## 5. Support Matrix Summary

| Target | Windows | macOS | Linux | Android | Notes |
|---|---|---|---|---|---|
| .NET Framework 4.8 | Supported | Not Supported | Not Supported | Not Supported | Windows-only runtime |
| .NET 8.0 | Supported | Supported | Supported | Supported | Subject to provider/runtime packaging validation |

## 6. Detailed Support Position

## 6.1 .NET Framework 4.8

Support status:
- Supported for Windows only

Expected use cases:
- Existing enterprise desktop applications
- Legacy console applications
- Existing .NET Framework libraries
- Existing Windows-hosted services
- Existing ASP.NET Framework applications where applicable

Not supported:
- macOS
- Linux
- Android

Reason:
- .NET Framework 4.8 is a Windows-only runtime

Implementation expectation:
- The Contracts, Application, and Infrastructure layers may produce `NET48`
  outputs where practical
- Any `NET48` sample applications are Windows-only
- All public documentation must clearly identify this limitation

## 6.2 .NET 8.0

Support status:
- Supported for Windows
- Supported for macOS
- Supported for Linux
- Supported for Android

Important note:
- Support is contingent on validating the selected SQLite provider and its
  runtime packaging behavior for each target environment

Expected use cases:
- Modern console applications
- Modern class libraries
- ASP.NET Core applications
- Cross-platform services and tools
- Android-hosted usage scenarios where supported by the selected provider
- Other modern .NET 8 consumer applications

## 7. Platform-Specific Expectations

## 7.1 Windows

Support priority:
- Highest priority for both target frameworks

Expected support:
- Full support for `.NET Framework 4.8`
- Full support for `.NET 8`
- Earliest validation target for packaging and integration

Expected scenarios:
- DLL consumption by other libraries
- Desktop applications
- Console applications
- Web applications
- Build/automation tools

## 7.2 macOS

Support priority:
- Supported under `.NET 8`

Expected support:
- Runtime support must be validated against the selected SQLite provider and
  packaging model
- Public contract parity should be maintained unless a provider/runtime
  constraint prevents it

Expected scenarios:
- Console tools
- .NET 8 applications
- Cross-platform service or library consumers

## 7.3 Linux

Support priority:
- Supported under `.NET 8`

Expected support:
- Runtime support must be validated against the selected SQLite provider and
  packaging model
- Linux distribution differences may need documentation if they affect runtime
  dependencies

Expected scenarios:
- Console tools
- Services
- Containers
- Server-hosted applications
- Build and automation utilities

## 7.4 Android

Support priority:
- Supported under `.NET 8`, subject to provider/runtime validation

Expected support:
- Must be treated as a distinct packaging and runtime validation target
- File system access patterns and deployment constraints may differ from desktop
  environments
- Documentation must explicitly describe any limitations

Expected scenarios:
- Android applications or libraries consuming SQLiteAPI where the provider
  supports the target runtime and packaging model

## 8. Contract Consistency Across Targets

The public Contracts layer should remain as consistent as possible between
`NET48` and `.NET 8`.

Rules:
- Public interfaces should have the same conceptual behavior across targets
- Request and result models should remain aligned where practical
- Additive differences should be preferred over target-specific fragmentation
- Provider/runtime differences should be handled internally whenever possible

If a feature cannot be supported uniformly, the limitation must be:
- documented explicitly
- represented clearly in behavior
- handled without introducing unnecessary contract instability

## 9. Runtime and Packaging Implications

SQLiteAPI is intended to be simple for consumers to adopt, but runtime
constraints must be documented accurately.

## 9.1 Managed Assembly Expectations

Consumers should ideally reference a minimal set of assemblies, expected to
include:
- Contracts assembly
- Application assembly
- SQLite infrastructure assembly

The exact packaging layout may be refined later, but the public guidance must
make the required runtime assets clear.

## 9.2 Native Runtime Considerations

SQLite implementations may require native runtime components depending on:
- target framework
- operating system
- deployment style
- selected provider

Therefore, platform support is not only a framework issue. It is also a runtime
packaging issue.

The final packaging strategy document must explicitly define:
- what managed DLLs are required
- what native assets are required
- how those assets are delivered
- what “standalone” means for each supported target

## 9.3 Definition of “Standalone”

For SQLiteAPI, “standalone” should mean:
- consumers do not need to install a separate database server
- consumers should not need a separate SQLite desktop application
- consumers should be able to include the required assemblies and assets with
  their own solution and call the API directly

“Standalone” does not automatically mean:
- zero runtime dependencies of any kind
- a single universal DLL for every framework and operating system combination

If native runtime assets are required, they must be documented and distributed in
the simplest practical form.

## 10. Output Naming Expectations

The final implementation may produce framework-specific outputs such as:
- `SQLiteAPI.Contracts_NET48.dll`
- `SQLiteAPI.Contracts_NET8.dll`
- `SQLiteAPI.Application_NET48.dll`
- `SQLiteAPI.Application_NET8.dll`
- `SQLiteAPI.Infrastructure.SQLite_NET48.dll`
- `SQLiteAPI.Infrastructure.SQLite_NET8.dll`

If platform-specific runtime assets are required, they must use clear naming and
documentation so consumers understand which assets are required for:
- Windows
- macOS
- Linux
- Android

## 11. Capability Expectations by Target

The target support matrix should aim for the following capability alignment.

| Capability | .NET Framework 4.8 | .NET 8 Windows | .NET 8 macOS | .NET 8 Linux | .NET 8 Android |
|---|---|---|---|---|---|
| Create database | Supported | Supported | Supported | Supported | Targeted |
| Delete database | Supported | Supported | Supported | Supported | Targeted |
| Check status | Supported | Supported | Supported | Supported | Targeted |
| Perform maintenance | Supported | Supported | Supported | Supported | Targeted |
| Execute non-query SQL | Supported | Supported | Supported | Supported | Targeted |
| Execute query returning result sets | Supported | Supported | Supported | Supported | Targeted |

Note:
- “Supported” means the capability is part of the intended baseline
- “Targeted” means it is intended, but requires explicit provider/runtime
  validation during implementation

## 12. Validation Requirements

Before claiming production readiness, SQLiteAPI should validate at minimum:

### 12.1 For .NET Framework 4.8
- Windows build success
- Windows runtime execution
- Database lifecycle operations
- Maintenance operations
- Query execution behavior
- Consumer reference experience

### 12.2 For .NET 8
- Windows build and runtime validation
- macOS build and runtime validation
- Linux build and runtime validation
- Android viability validation for selected packaging/provider approach
- Cross-platform parity for core contract behavior

## 13. Testing Implications

The support matrix has direct testing consequences.

Testing should include:
- framework-specific unit tests where needed
- integration tests for SQLite behaviors
- file system behavior validation by target
- packaging/deployment validation for supported platforms
- smoke tests for example applications

The first implementation phase may prioritize:
1. Windows on `NET48`
2. Windows on `.NET 8`
3. Linux on `.NET 8`
4. macOS on `.NET 8`
5. Android on `.NET 8`

This order is recommended for practical rollout, not as a permanent priority
statement.

## 14. Documentation Requirements

All public documentation must clearly communicate:
- that `.NET Framework 4.8` is Windows-only
- that `.NET 8` is the cross-platform target
- that Android support depends on provider/runtime validation
- that runtime packaging may differ by platform
- exactly which files consumers need to include for each target

No documentation should imply that one DLL alone will necessarily satisfy every
framework and platform combination unless that is proven by the final packaging
approach.

## 15. Forward Compatibility

Future evaluation may include:
- .NET 9
- additional mobile/runtime targets
- packaging simplification
- expanded support statements after implementation validation

These future considerations must remain incremental and must not destabilize the
initial public contract surface.

## 16. Final Principle

The framework and platform strategy for SQLiteAPI must remain:
- explicit
- realistic
- testable
- consumer-friendly
- documentation-first

Support claims must be based on validated runtime behavior, not assumptions.
