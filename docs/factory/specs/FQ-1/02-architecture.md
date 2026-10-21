# FQ-1 Gate 2 - Architecture: About page

## Systems touched
- `WebApplication1/Controllers/HomeController.cs` - one new action.
- `WebApplication1/Views/Home/About.cshtml` - new view.
- `WebApplication1/Views/Shared/_Layout.cshtml` - one new nav `<li>`.

## New endpoints and data
- `GET /Home/About` -> `HomeController.About()`, returns `View()`. No model, no storage, no
  parameters. Conventional routing in `Program.cs` already resolves it; `Program.cs` is NOT modified.

## Call flow
1. Browser requests `/Home/About` (or clicks the nav link rendered with
   `asp-controller="Home" asp-action="About"`).
2. Default route `{controller=Home}/{action=Index}/{id?}` maps to `HomeController.About`.
3. Action returns `View()`, Razor renders `Views/Home/About.cshtml` inside `_Layout.cshtml`.

## External dependencies
None.

## Load-bearing paths
None. All paths fall under AUTOMATABLE (`Views/**`, `Controllers/**`). Default `full` gates.

## What could break elsewhere
- Navbar width on narrow screens: one more item in a collapsible navbar; low risk.
- No existing tests; none can be affected. A new test project is not required by the issue.
  Note: charter requires "a test that fails without it"; no test project exists and adding one
  touches `*.slnx` / `*.csproj` (load-bearing). Open question for Gate 3/4.

## Correction to Gate 1
Gate 1 said the current page link is highlighted "matching other nav links". The existing
nav does not highlight the active link, so this spec does NOT add active-state styling
(it would be new behavior outside the issue). Proposed: drop that bullet from Gate 1.
