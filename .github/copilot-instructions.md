# GitHub Copilot Instructions for Slag Refined Plus (Continued) Mod

## Mod Overview and Purpose
Slag Refined Plus (Continued) is an update to the Enraks mod that rebalances resource extraction from slag chunks in RimWorld. The mod aims to make slag more valuable by increasing the amount of resources extracted, adding components, and reducing the work time for smelting.

## Key Features and Systems
- **Rebalanced Slag Smelting**: The mod increases the amount of resources extracted from slag chunks, such as steel, silver, gold, and plasteel, and adds a component to each smelt.
- **New Slag Types**: Introduces new slag types like Sterile Slag, Luxury Slag, and Plasteel Slag, each with unique resource outputs.
- **Incident System**: Adds a new incident called "Slag Debris" that can drop various slag-related resources.

## Coding Patterns and Conventions
- **C# Code Structure**:
  - Use meaningful class and method names.
  - Follow the RimWorld coding conventions, such as using PascalCase for class and method names.
  - Organize code into logical classes and methods to improve readability and maintainability.
  
- **XML Definitions**:
  - Use consistent naming conventions for XML elements and attributes.
  - Ensure that XML definitions are properly structured and validated against the RimWorld schema.

## XML Integration
- **Def Files**: The mod uses XML files to define new game elements such as `IncidentDef`, `ThingDef`, and `ThingSetMakerDef`.
  - Example: `Incidents_SlagScatter.xml` defines new slag-related incidents.

- **XML Structure**:
  - Each XML file should contain a single root element that corresponds to the type of definition being made (e.g., `Defs` for definitions).
  - Ensure that all required attributes and child elements are present and correctly formatted.

## Harmony Patching
- **Harmony Patching**:
  - Use Harmony to patch existing RimWorld code to modify behavior.
  - Ensure that patches are applied correctly and do not interfere with other mods.
  - Follow the Harmony documentation and best practices for creating patches.

- **Patch Example**:
  - Example: Patching the `Smelting` work type to modify the amount of resources produced.

## Suggestions for Copilot
- **C# Suggestions**:
  - Request code snippets for creating new classes and methods.
  - Request examples of Harmony patches for modifying existing RimWorld behavior.

- **XML Suggestions**:
  - Request examples of XML definitions for new game elements.
  - Request validation of XML files against the RimWorld schema.

- **General Suggestions**:
  - Request advice on balancing game mechanics.
  - Request tips for ensuring mod compatibility with other mods.

By following these guidelines, developers can contribute effectively to the Slag Refined Plus (Continued) mod and ensure that the code and XML files are well-structured and maintainable.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

