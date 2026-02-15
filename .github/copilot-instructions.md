# Copilot Instructions

> **Important:** This module is part of the BASE framework. 
> For complete coding standards, design patterns, and architectural guidelines, refer to the parent repository's instructions.

## Parent References
- **Main Instructions:** `../../.github/copilot-instructions.md` (in SERVICE repo)
- **EditorConfig:** `../../.editorconfig` (in SERVICE repo)

## Quick Rules (from parent)
- **ONE TYPE PER FILE** - Every interface, class, enum, struct, record MUST be in its own file
- Use `this.` prefix for instance members
- Use bracket-style namespaces `namespace X { }`, NOT file-scoped `namespace X;`
- Always use braces for if/while/for/etc - no single-line braceless statements
- Private fields: `_fieldName`, Properties: `PascalCase`

## This Module
This logical module follows DDD layering:
- `*.Substrate` / `*.Shared` - Contracts, interfaces, marker interfaces
- `*.Domain` - Domain models and services
- `*.Infrastructure` - Technical implementations
- `*.Application` - Application services, DTOs
- `*.Interfaces.*` - API endpoints (REST, OData, GraphQL, Web)

For access control, permissions, share-based security patterns - see parent `copilot-instructions.md`.
