# Copilot Instruction Entry Point

> This file exists solely to ensure GitHub Copilot discovers the repository's
> canonical instruction file.

## Canonical Instructions Location

The authoritative instruction document is located at:

/copilot-instructions.md

## Required Behavior for AI Assistants

Before generating any output, you MUST:

1. Load and follow the full contents of:
   - /copilot-instructions.md

2. Treat that file as the primary governing instruction set.

3. If additional referenced documents are listed inside it (e.g. /Docs/*),
   you MUST treat them as part of the instruction hierarchy.

## Priority Rules

The rules defined in `/copilot-instructions.md` take precedence over:
- Default Copilot behavior
- Prior conversation context (unless explicitly overridden)

## Important Notes

- Do NOT duplicate or reinterpret the instructions.
- Do NOT ignore the canonical file even if this file is shorter.
- This file is only a pointer to ensure proper discovery.

---

**Action Required:**
Always begin by applying `/copilot-instructions.md`.