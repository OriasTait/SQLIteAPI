## 🤖 Copilot Instructions (Enterprise – Canonical)
 
**Scope:** This repository  
**Authority:** MUST comply with:
- `/Docs/AI-Guidelines.md`
- `/Docs/OS-Structure.md`

---

## SECTION 1 — Governance & Enforcement

### 1. Purpose

This document defines **operational rules** for GitHub Copilot and any other AI assistant used with this repository.

This file does **NOT** define architecture or physical structure.

The physical directory and repository layout is defined **exclusively** in:

```
/Docs/OS-Structure.md
```

AI assistants must not infer, redefine, or modify structure outside of that document.

If there is any conflict between:
- this file
- `/Docs/AI-Guidelines.md`
- requirements.md
- or a user prompt

**Resolution order MUST be:**
1. `/Docs/OS-Structure.md`
2. `/Docs/AI-Guidelines.md`
3. `copilot-instructions.md`
4. requirements.md
5. User prompt

---

### 2. Mandatory Compliance Rules

Before generating ANY output, the AI assistant MUST assume:
- The enterprise solution structure is **frozen**
- Root directories may not be changed
- New projects may not be introduced unless explicitly instructed
- Layers may not be merged, collapsed, or reorganized

Any output that violates `/Docs/OS-Structure.md` or `/Docs/AI-Guidelines.md` is **invalid**.

---

### 3. Allowed AI Activities

The AI assistant MAY:
- Generate code **inside an existing folder only**
- Implement classes **defined by existing interfaces**
- Extend existing projects without altering their role
- Generate SQL scripts within `/Databases/<Provider>/`
- Generate ONE class, script, or file per request
- Generate incremental changes only

---

### 4. Explicitly Forbidden AI Activities

The AI assistant MUST NOT:
- Propose or apply architectural changes
- Move folders or projects
- Rename layers or roots
- Generate a complete solution in one output
- Create new top-level directories
- Bypass Contracts, Application, or API layers
- Generate C# code inside `/Databases`
- Generate SQL inside `/SRC`

---

## SECTION 2 — General Code Generation Rules

All AI-generated output MUST:
- Compile successfully in its target project
- Preserve all existing comments unless explicitly instructed otherwise
- Avoid `SELECT *`
- Avoid placeholders, ellipses, or TODO comments
- Wrap lines at approximately 95 characters
- Use Eastern Time (EST) for all date/time logic unless overridden
- Include full file paths and full contents for any multi-file output
- Add comments explaining **why** a change was made

---

## SECTION 3 — Technology-Specific Rules

### 3.1 SQL Rules (Mandatory / PR-Enforced)

- SQL changes MUST use parameterized queries and `sp_executesql`.
- SQL changes MUST use schema-qualified object names.
- SQL scripts MUST include `SET NOCOUNT ON` at the start and `SET NOCOUNT OFF` at the end.
- SQL scripts MUST use TRY/CATCH with explicit transactions where applicable.
- SQL changes MUST NOT use unsafe features such as `xp_cmdshell`.
- SQL scripts SHOULD be idempotent where possible.
- SSDT-based deployments rely on `.dacpac`.

#### SQL Editor Formatting Standard (Mandatory)

All contributors MUST format SQL using these Visual Studio settings:

- Indenting: Block
- Tab size: 2
- Indent size: 2
- Tabs: Keep tabs

Visual Studio option paths:
- __Tools > Options > Text Editor > SQL Server Tools > Tabs__
- __Tools > Options > Text Editor > T-SQL90 > Tabs__ (if installed)

#### Pull Request Enforcement (Non-Negotiable)

For any pull request containing SQL changes:

1. Reviewers MUST verify compliance with the SQL formatting standard above.
2. Any non-compliant SQL formatting MUST result in **Request Changes**.
3. PR approval MUST be withheld until SQL formatting is corrected.
4. Non-compliant PRs MUST NOT be merged.

---

### 3.2 PowerShell Rules

- Target PowerShell 5.1
- Use Try / Catch / Finally
- Implement verbose logging
- Validate all parameters
- Use `System.Data.SqlClient` or `Invoke-Sqlcmd` with parameters

---

### 3.3 C# Rules

- Target .NET 8.0 unless explicitly overridden
- Use block-scoped namespaces
- Use explicit, classic C# syntax
- Maintain architectural flow:
  Controllers → Services → Repositories → DbContext → SQL
- Register dependencies via `Program.cs`
- Always provide interfaces with concrete implementations

---

## SECTION 4 — Enforcement Reminder

**The AI assistant is a productivity tool, not an architect.**

All AI output must be:
- Scoped
- Incremental
- Fully compliant with `/Docs/OS-Structure.md` and `/Docs/AI-Guidelines.md`

Failure to comply invalidates the output.

**END OF DOCUMENT**
