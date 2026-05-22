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

However, support must be interpreted through three distinct lenses:
1. standard .NET runtime support
2. Unity 6 consumer compatibility
3. validated provider/runtime packaging support

A support statement is incomplete unless all three are considered.

## 5. Support Matrix Summary

### 5.1 Standard .NET Runtime Matrix

| Target | Windows | macOS | Linux | Android | Notes |
|---|---|---|---|---|---|
| .NET Framework 4.8 | Supported | Not Supported | Not Supported | Not Supported | Standard Microsoft .NET Framework runtime position |
| .NET 8.0 | Supported | Supported | Supported | Supported | Subject to provider/runtime packaging validation |

### 5.2 Unity 6 Consumer Compatibility Matrix

| Consumer Context | Windows | macOS | Linux | Android | Notes |
|---|---|---|---|---|---|
| Unity 6 using `NET_Unity_4_8` | Targeted | Targeted | Targeted | Targeted | Managed assembly compatibility is possible, subject to IL2CPP/AOT and SQLite provider/runtime validation |

Unity's `NET_Unity_4_8` profile targets the union of the `.NET Framework 4.8`
and `.NET Standard 2.1` API surface, so Unity compatibility must be evaluated
separately from the standard Microsoft `.NET Framework 4.8` runtime statement.

## 6. Detailed Support Position

## 6.1 Standard .NET Framework 4.8

Support status:
- Supported for Windows only in standard .NET runtime scenarios

Expected use cases:
- Existing enterprise desktop applications
- Legacy console applications
- Existing .NET Framework libraries
- Existing Windows-hosted services
- Existing ASP.NET Framework applications where applicable

Not supported in standard runtime terms:
- macOS
- Linux
- Android

Reason:
- standard `.NET Framework 4.8` is a Windows-only runtime

Implementation expectation:
- any `NET48` general-purpose output intended for standard non-Unity runtime
  consumption should be documented as Windows-only
- all public documentation must clearly identify this limitation

## 6.2 Unity 6 Consumer Position

Support status:
- Unity 6 consumption is targeted for Windows, macOS, Linux, and Android
- support must be validated rather than assumed

Important notes:
- Unity 6 consumers use Unity's own scripting/runtime compatibility model
- Unity's `NET_Unity_4_8` profile is not equivalent to claiming that the
  Microsoft `.NET Framework 4.8` runtime itself runs on every target platform
- managed compatibility alone is not sufficient to prove SQLiteAPI support

Unity builds frequently rely on IL2CPP and ahead-of-time compilation for target
platform output, which can affect native interop, reflection usage, generic code
generation, and runtime packaging behavior.

Implementation expectation:
- Unity compatibility must be tested explicitly
- provider/native packaging must be tested explicitly
- Android support must remain a validated target until proven in working builds

## 6.3 .NET 8.0

Support status:
- Supported for Windows
- Supported for macOS
- Supported for Linux
- Supported for Android

Important note:
- support is contingent on validating the selected SQLite provider and its
  runtime packaging behavior for each target environment

Expected use cases:
- modern console applications
- modern class libraries
- ASP.NET Core applications
- cross-platform services and tools
- Android-hosted usage scenarios where supported by the selected provider
- other modern .NET 8 consumer applications

## 7. Platform-Specific Expectations

## 7.1 Windows

Support priority:
- Highest priority for both target frameworks

Expected support:
- Full support for standard `.NET Framework 4.8`
- Full support for `.NET 8`
- Unity 6 support is targeted and must be validated
- Earliest validation target for packaging and integration

Expected scenarios:
- DLL consumption by other libraries
- Desktop applications
- Console applications
- Web applications
- Build/automation tools
- Unity consumer applications

## 7.2 macOS

Support priority:
- Supported under `.NET 8`
- Targeted for Unity 6 consumption

Expected support:
- Runtime support must be validated against the selected SQLite provider and
  packaging model
- Public contract parity should be maintained unless a provider/runtime
  constraint prevents it
- Unity 6 behavior must be validated independently from standard .NET behavior

Expected scenarios:
- Console tools
- .NET 8 applications
- Cross-platform service or library consumers
- Unity consumer applications

## 7.3 Linux

Support priority:
- Supported under `.NET 8`
- Targeted for Unity 6 consumption

Expected support:
- Runtime support must be validated against the selected SQLite provider and
  packaging model
- Linux distribution differences may need documentation if they affect runtime
  dependencies
- Unity 6 behavior must be validated independently from standard .NET behavior

Expected scenarios:
- Console tools
- Services
- Containers
- Server-hosted applications
- Build and automation utilities
- Unity consumer applications

## 7.4 Android

Support priority:
- Supported under `.NET 8`, subject to provider/runtime validation
- Targeted for Unity 6 consumption, subject to IL2CPP/AOT and packaging
  validation

Expected support:
- Must be treated as a distinct packaging and runtime validation target
- File system access patterns and deployment constraints may differ from desktop
  environments
- Documentation must explicitly describe any limitations

Expected scenarios:
- Android applications or libraries consuming SQLiteAPI where the provider
  supports the target runtime and packaging model
- Unity consumer applications where validated

## 8. Contract Consistency Across Targets

The public Contracts layer should remain as consistent as possible between
`NET48`, Unity-compatible usage scenarios, and `.NET 8`.

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
- Unity/IL2CPP packaging behavior where applicable

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

Capability expectations must distinguish between:
- standard .NET runtime support
- Unity 6 consumer support

### 11.1 Standard .NET Runtime Capability Matrix

| Capability | .NET Framework 4.8 | .NET 8 Windows | .NET 8 macOS | .NET 8 Linux | .NET 8 Android |
|---|---|---|---|---|---|
| Create database | Supported | Supported | Supported | Supported | Targeted |
| Delete database | Supported | Supported | Supported | Supported | Targeted |
| Check status | Supported | Supported | Supported | Supported | Targeted |
| Perform maintenance | Supported | Supported | Supported | Supported | Targeted |
| Execute non-query SQL | Supported | Supported | Supported | Supported | Targeted |
| Execute query returning result sets | Supported | Supported | Supported | Supported | Targeted |

### 11.2 Unity 6 Consumer Capability Matrix

| Capability | Unity 6 Windows | Unity 6 macOS | Unity 6 Linux | Unity 6 Android |
|---|---|---|---|---|
| Create database | Targeted | Targeted | Targeted | Targeted |
| Delete database | Targeted | Targeted | Targeted | Targeted |
| Check status | Targeted | Targeted | Targeted | Targeted |
| Perform maintenance | Targeted | Targeted | Targeted | Targeted |
| Execute non-query SQL | Targeted | Targeted | Targeted | Targeted |
| Execute query returning result sets | Targeted | Targeted | Targeted | Targeted |

Note:
- `Supported` means the capability is part of the intended validated baseline
- `Targeted` means the capability is intended but still requires explicit
  provider/runtime and platform validation

## 12. Validation Requirements

Before claiming production readiness, SQLiteAPI should validate at minimum:

### 12.1 For standard .NET Framework 4.8
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

### 12.3 For Unity 6 Consumption
- managed assembly compatibility validation
- IL2CPP/AOT compatibility validation where applicable
- provider/native packaging validation
- file system and deployment validation by target platform
- working scenario validation for Windows, macOS, Linux, and Android as claimed

## 13. Testing Implications

The support matrix has direct testing consequences.

Testing should include:
- framework-specific unit tests where needed
- integration tests for SQLite behaviors
- file system behavior validation by target
- packaging/deployment validation for supported platforms
- smoke tests for example applications
- Unity 6 compatibility validation where support is claimed

The first implementation phase may prioritize:
1. Windows on `NET48`
2. Windows on `.NET 8`
3. Linux on `.NET 8`
4. macOS on `.NET 8`
5. Unity 6 Windows
6. Unity 6 Android
7. Unity 6 macOS
8. Unity 6 Linux
9. Android on `.NET 8`

This order is recommended for practical rollout, not as a permanent priority
statement.

## 14. Documentation Requirements

All public documentation must clearly communicate:
- that standard `.NET Framework 4.8` is Windows-only
- that `.NET 8` is the primary standard cross-platform target
- that Unity 6 compatibility must be evaluated separately from standard .NET
  runtime statements
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
- expanded Unity-specific guidance

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
