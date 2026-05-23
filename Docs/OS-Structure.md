# 🧱 Enterprise OS / Repository Structure (Canonical)

**Document Status:** Canonical / Non‑Negotiable  
**Audience:** Humans and AI Assistants  
**Location:** /Docs/OS-Structure.md

---

## 1. Purpose

This document defines the **physical, operating‑system‑level structure** of the enterprise repository.  
It is the **single source of truth** for all directory names, hierarchy, and physical placement of assets.

AI assistants and humans must follow this structure **verbatim**. Any deviation is invalid.

---

## 2. Canonical Enterprise Directory Structure

```
EnterpriseSolution/
│
├── .github/
│
├── Builds/                 # Build outputs, CI artifacts
│   ├── Artifacts/
│   ├── Packages/
│   └── Logs/
│
├── Config/                 # Environment-specific configuration
│   ├── Base/
│   │   └── appsettings.json
│   ├── Dev/
│   ├── QA/
│   ├── UAT/
│   └── Prod/
│
├── Databases/              # Physical database assets (DBA-owned)
│   ├── SqlServer/
│   │   ├── Schema/
│   │   ├── Migrations/
│   │   ├── Stored-procedures/
│   │   ├── Functions/
│   │   ├── Agent-Jobs/
│   │   └── Reference-Data/
│   ├── PostgreSQL/
│   │   ├── Schema/
│   │   ├── Migrations/
│   │   ├── Functions/
│   │   └── Reference-Data/
│   ├── MySql/
│   │   ├── Schema/
│   │   ├── Migrations/
│   │   └── Reference-data/
│   └── SQLite/
│       ├── Schema/
│       ├── Migrations/
│       └── Seed-Data/
│
├── Docs/                   # Governance, architecture, SOPs
│   ├── Architecture/
│   ├── Adr/
│   ├── Diagrams/
│   ├── Runbooks/
│   │
│   ├── AI-Guidelines.md
│   ├── Business-Requirements.md
│   ├── Implementation-Requirements.md
│   ├── OS-Structure.md
│   ├── Requirement-Refinement.md
│   └── VisualStudio-LogicalLayout.md
│
├── Infrastructure/         # IaC (Terraform, Bicep, ARM, Pipelines)
│
├── Scripts/                # Automation and maintenance
│   ├── Deployment/
│   ├── Database/
│   └── Maintenance/
│
├── SRC/                    # Application source code
│   ├── Domain/
│   ├── Contracts/
│   ├── Application/
│   ├── Infrastructure/
│   └── Presentation/
│
├── UIs/                    # End-user applications
│
├── Tests/                  # Unit, integration, performance, security tests
│
├── Tools/                  # Internal developer tooling
│
├── copilot-instructions.md
├── My_Solution.sln
└── README.md
```

---

## 3. Enforcement

- This structure is **frozen**.
- No AI or human may rename, move, collapse, or reorganize these directories.
- Logical (IDE) layout must never override physical layout.

**This document always wins in any conflict involving structure.**

---
**END OF DOCUMENT**
