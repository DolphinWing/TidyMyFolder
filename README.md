# TidyMyFolder

An intelligent dual-pane directory organizer and classification tool for Windows.

`TidyMyFolder` helps organize cluttered working directories or download folders into structured destinations by analyzing folder names, extracting key tokens, and automatically suggesting matching target directories for one-click relocation.

---

## ✨ Features

- **Dual-Pane TreeView Navigation**:
  - Left pane: Source directory (folders waiting to be organized).
  - Right pane: Destination directory (the organized archive).
  - On-demand lazy loading of subdirectories for fast browsing.
- **Token-Based Fuzzy Directory Search**:
  - Automatically splits the selected source folder name using common delimiters (`-`, `_`, ` `, `[`, `]`, `(`, `)`, etc.).
  - Recursively searches the destination tree for matching paths containing any of the extracted tokens.
- **One-Click Dispatch & Relocation**:
  - Move the selected source folder into the matched destination path (`Directory.Move`).
  - Automatically refreshes both source and destination tree nodes.
- **Shell Integration**:
  - Context menu and shortcuts to reveal selected directories in Windows Explorer.
  - Quick directory deletion for unwanted folders.

---

## 🔍 Architecture & Known Limitations (Technical Debt)

The core logic resides in [`Form1.cs`](file:///D:/work/misc/workspace_CSharp/TidyMyFolder/TidyMyFolder/Form1.cs). Written in the .NET Framework 3.5 era, the current implementation has several architectural bottlenecks:

1. **Synchronous UI Blocking on I/O**:
   - Directory searching uses `Directory.GetDirectories(search_path, "*" + pattern + "*", SearchOption.AllDirectories)` directly on the main UI thread.
   - Deep directory trees or large disk structures freeze the UI during search.
2. **Unhandled Permission Errors**:
   - Recursive searches do not handle `UnauthorizedAccessException` gracefully when encountering system-protected or restricted directories (e.g., `System Volume Information`).
3. **Naive Substring Matching**:
   - Each token generates a separate wildcard search (`*token*`).
   - Multiple matching tokens can return duplicate results without confidence scoring or similarity ranking.
4. **Tight UI / Business Logic Coupling**:
   - File system I/O, tokenization, and UI event handling are all coupled within the WinForms code-behind.

---

## 🚀 Modernization & Refactoring Roadmap

For anyone interested in maintaining or upgrading this utility, here is the recommended modernization path:

- [ ] **Target Framework Modernization**:
  - Upgrade to **.NET 8** or **.NET 9** (SDK-style project format).
- [ ] **Non-Blocking Async I/O**:
  - Refactor search logic to `async/await` using `Task.Run` with `IAsyncEnumerable<string>`.
  - Add `CancellationToken` support to allow cancelling long-running scans.
- [ ] **Safe Directory Traversal**:
  - Implement a safe enumerator using `Directory.EnumerateDirectories` that catches `UnauthorizedAccessException` and skips restricted nodes.
- [ ] **Ranked Similarity Scoring**:
  - Replace naive substring globbing with string similarity algorithms (Levenshtein distance, Jaro-Winkler, or Token Set Ratio).
  - Rank search results by match percentage and highlight the highest-confidence destination.
- [ ] **Collision Handling & Undo Support**:
  - Prompt user options upon destination collision (e.g., *Overwrite*, *Auto-Rename*, *Skip*).
  - Add an operation stack supporting `Ctrl+Z` Undo for accidental moves.
- [ ] **Modern UI**:
  - Separate concerns into MVVM / Clean Architecture.
  - Re-implement UI using modern WPF or WinUI 3 (Fluent Design, High DPI, Dark Mode).

---

## 🛠️ Build & Requirements

- **Original Target**: .NET Framework 3.5
- **IDE**: Visual Studio 2008 / 2010 or higher (Visual Studio 2022 compatible with .NET 3.5 development workload installed).
- **Platform**: Windows 7 / 10 / 11

### Quick Build
Open `TidyMyFolder.sln` in Visual Studio and build in `Release` configuration:
```shell
msbuild TidyMyFolder.sln /p:Configuration=Release
```

---

## 📄 License

This project is licensed under the [MIT License](LICENSE) - see the [LICENSE](LICENSE) file for details.
