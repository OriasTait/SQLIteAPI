# SQLiteAPI Provider Selection Decision

## 1. Purpose

This document records the initial provider-selection direction for SQLiteAPI.

Its purpose is to define the SQLite provider strategy that best supports the
approved framework targets, supported operating systems, packaging goals, and
open-source adoption objectives for the SQLiteAPI rewrite.

This document must comply with:
- `/Docs/OS-Structure.md`
- `/Docs/AI-Guidelines.md`
- `/copilot-instructions.md`
- `/Docs/architecture/SQLiteAPI-Architecture-Blueprint.md`
- `/Docs/architecture/SQLiteAPI-Public-Contracts-Specification.md`
- `/Docs/architecture/SQLiteAPI-Framework-and-Platform-Support-Matrix.md`
- `/Docs/architecture/SQLiteAPI-Packaging-and-Dependency-Strategy.md`

This document is a design decision record. It does not define final source code.

## 2. Decision Summary

The initial recommended provider strategy for SQLiteAPI is:

1. Define a provider-agnostic public Contracts layer
2. Isolate all provider-specific logic inside `/SRC/Infrastructure`
3. Select a provider approach that can support:
   - `.NET Framework 4.8` on Windows
   - `.NET 8` on Windows
   - `.NET 8` on macOS
   - `.NET 8` on Linux
4. Treat Android as a separately validated target rather than assuming full
   parity on day one
5. Prefer a provider strategy that minimizes consumer complexity without hiding
   real runtime requirements

The initial implementation should avoid leaking any provider-specific classes
into the Contracts layer.

## 3. Design Requirements Driving the Decision

The provider choice must support the following requirements:
- stable public API surface
- Windows support for `.NET Framework 4.8`
- modern cross-platform support for `.NET 8`
- open-source usability
- manageable packaging complexity
- realistic runtime dependency documentation
- support for core SQLite operations
- suitability for example applications and automated testing

## 4. Decision Principles

The provider-selection decision must prioritize:
- runtime compatibility
- long-term maintainability
- packaging clarity
- consumer simplicity
- implementation isolation
- ability to test consistently
- minimal architectural drift

The decision must not prioritize convenience at the cost of inaccurate support
claims.

## 5. Candidate Provider Approaches

The following broad provider approaches should be considered.

### 5.1 Provider Approach A - Single Unified Provider Strategy

Description:
- Use one provider family for both `.NET Framework 4.8` and `.NET 8` if a single
  practical choice can satisfy the approved targets

Potential advantages:
- simpler implementation model
- fewer provider-specific variations
- easier internal consistency
- simpler documentation if runtime behavior is sufficiently uniform

Potential disadvantages:
- may impose packaging/runtime tradeoffs that are suboptimal on one target
- may not provide the best Android path
- may still require multiple native runtime assets across platforms

### 5.2 Provider Approach B - Split Provider Strategy by Target Family

Description:
- Use one provider path for `.NET Framework 4.8`
- Use another provider path for `.NET 8`

Potential advantages:
- more flexibility by target framework
- can optimize for legacy Windows on `NET48`
- can optimize for modern cross-platform support on `.NET 8`

Potential disadvantages:
- more internal complexity
- higher maintenance burden
- greater testing surface area
- possible behavioral differences between framework targets

### 5.3 Provider Approach C - Provider Abstraction with Replaceable Implementations

Description:
- Standardize on a provider-agnostic internal abstraction
- allow one primary implementation initially
- leave room for future alternate implementations

Potential advantages:
- strongest architectural isolation
- easier long-term evolution
- simpler future experimentation
- reduces risk of public contract contamination

Potential disadvantages:
- requires disciplined implementation design
- may add a small amount of internal complexity early

## 6. Evaluation Criteria

Each provider strategy should be evaluated against:
- `.NET Framework 4.8` compatibility
- `.NET 8` compatibility
- Windows compatibility
- macOS compatibility
- Linux compatibility
- Android feasibility
- packaging complexity
- native dependency complexity
- documentation complexity
- open-source consumer friendliness
- long-term maintenance burden

## 7. Required Capability Support

The selected provider strategy must support, or be able to support
incrementally, the following capabilities:
- create database
- delete database
- check database existence and accessibility
- run maintenance operations
- execute non-query SQL
- execute scalar SQL
- execute queries returning result sets
- support parameterized commands
- support transaction-aware operations

## 8. Preferred Architectural Position

The preferred architectural position is:

- Contracts remain provider-agnostic
- Application orchestrates operations without provider-specific exposure
- Infrastructure contains the concrete provider integration
- provider-specific runtime/packaging details are documented, not leaked through
  Contracts
- future alternate provider implementations remain possible if needed

This means the solution should adopt **provider abstraction internally**, even if
version 1 ships with only one concrete provider implementation.

## 9. Initial Recommendation

The initial recommended decision is:

### 9.1 Public API Strategy
- Provider-agnostic Contracts
- Provider-specific implementation isolated to Infrastructure

### 9.2 Implementation Strategy
- Start with a single primary provider implementation path where practical
- Design Infrastructure so an alternate implementation can be added later if
  necessary
- Avoid a hard dependency in Contracts on any provider-specific types

### 9.3 Framework Strategy
- Validate the chosen implementation first for:
  - `.NET Framework 4.8` on Windows
  - `.NET 8` on Windows
  - `.NET 8` on Linux
  - `.NET 8` on macOS
- Treat Android as a phase-following validation target

## 10. Why a Provider-Agnostic Contract Matters

A provider-agnostic contract is required because it:
- preserves long-term flexibility
- reduces consumer coupling to low-level implementation details
- allows packaging changes without contract redesign
- helps support multiple framework families
- supports potential future provider substitution if runtime realities require it

This aligns directly with the enterprise layering rules and the open-source goals
for SQLiteAPI.

## 11. Android Position

Android support remains an approved target, but it should be treated as
**validated support**, not assumed support.

Initial decision:
- do not promise day-one parity until provider/runtime behavior is validated
- ensure Contracts are compatible with Android-targeted usage scenarios
- ensure Infrastructure is designed so Android-specific packaging can be handled
  without breaking the public surface

This protects the project from overcommitting before runtime validation is
complete.

## 12. Packaging Impact of the Decision

The provider decision directly affects:
- number of required assemblies
- native runtime asset requirements
- platform-specific deployment instructions
- sample application design
- support claims in open-source documentation

Therefore, the chosen provider strategy must remain closely aligned with the
packaging strategy document.

## 13. Dependency Exposure Rules

The chosen provider strategy must follow these rules:
- provider-specific types must not appear in Contracts
- provider-specific exceptions must not become the public API surface
- provider-specific configuration must be translated into SQLiteAPI request or
  configuration models where practical
- runtime dependency requirements must be documented explicitly

## 14. Implementation Risk Considerations

The following risks must be managed regardless of provider selection:
- native runtime packaging differences by platform
- behavioral differences across operating systems
- file locking and file path differences
- Android-specific runtime and packaging behavior
- potential differences between legacy and modern framework execution patterns

These risks reinforce the decision to isolate provider logic in Infrastructure.

## 15. Testing Implications

The provider decision requires testing at multiple levels:
- contract behavior tests
- application orchestration tests
- infrastructure integration tests
- cross-framework tests
- cross-platform validation where supported
- packaging/deployment smoke tests

The initial recommended validation order remains:
1. Windows on `NET48`
2. Windows on `.NET 8`
3. Linux on `.NET 8`
4. macOS on `.NET 8`
5. Android on `.NET 8`

## 16. Open-Source Implications

Because SQLiteAPI will be open source, the provider strategy must support:
- clear documentation
- reproducible setup
- understandable deployment guidance
- minimal ambiguity for external users
- room for future contributions without destabilizing the API

A provider-agnostic contract with isolated implementation gives the strongest
foundation for community understanding and future maintenance.

## 17. Decision Record Statement

The initial decision is:

- SQLiteAPI will use a provider-agnostic Contracts layer
- SQLiteAPI will isolate all concrete SQLite provider behavior in Infrastructure
- SQLiteAPI version 1 should begin with one primary provider implementation path
  where practical
- SQLiteAPI will avoid promising Android production parity until runtime and
  packaging validation are complete
- SQLiteAPI may support alternate Infrastructure implementations in the future if
  needed without redesigning the public contract surface

## 18. Deferred Detailed Selection Items

The following detailed choices are intentionally deferred until implementation
planning:
- exact provider package/library selection
- exact native asset delivery model
- exact Android packaging mechanics
- exact DI registration strategy by framework target

These decisions should be captured in follow-up implementation records once the
team validates the preferred provider path technically.

## 19. Immediate Next Artifacts

After approval of this provider-selection decision, the next recommended
artifacts are:
1. Initial Contracts project file design
2. Initial Contracts folder/file plan
3. The first interface definitions in `/SRC/Contracts`
4. The first DTO and result model definitions in `/SRC/Contracts`
5. A sample usage specification document

## 20. Final Principle

The SQLiteAPI provider strategy must remain:
- provider-agnostic at the public boundary
- explicit in implementation
- realistic in support claims
- flexible in packaging
- incremental in rollout
- safe for long-term open-source evolution

The public API must remain more stable than the provider implementation behind
it.
