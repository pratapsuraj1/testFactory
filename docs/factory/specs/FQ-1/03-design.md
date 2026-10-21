# FQ-1 Gate 3 - Program design: About page

## Files
New:
- `WebApplication1/Views/Home/About.cshtml`
- `WebApplication1.Tests/WebApplication1.Tests.csproj` (xUnit, net10.0, references web project) - LOAD_BEARING
- `WebApplication1.Tests/HomeControllerTests.cs`

Modified:
- `WebApplication1/Controllers/HomeController.cs` - add action
- `WebApplication1/Views/Shared/_Layout.cshtml` - add nav item after Privacy
- `WebApplication1.slnx` - add test project - LOAD_BEARING

Not modified: `Program.cs`, any existing project settings.

## Contracts (no implementations)
```csharp
// HomeController
public IActionResult About();            // returns ViewResult, default view name, no model

// HomeControllerTests
[Fact] public void About_ReturnsViewResult_WithDefaultViewAndNoModel();
```
View: `@{ ViewData["Title"] = "About"; }`, an `<h1>`, one `<p>` of fixed text.
Nav: `<li class="nav-item"><a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="About">About</a></li>`

## Call stack
Request `/Home/About` -> routing -> `HomeController.About()` -> `View()` -> Razor
`Views/Home/About.cshtml` -> `_Layout.cshtml` -> response.

## Tests
- `About_ReturnsViewResult_WithDefaultViewAndNoModel`: proves the action exists and returns a
  view; fails to compile/run without the action.
- `dotnet build` proves the Razor view and nav `asp-action` tag helper compile.
- (Optional) nav-link presence is not unit-testable without a WebApplicationFactory integration
  test, which would add `Microsoft.AspNetCore.Mvc.Testing` as a dependency; deferred.

## Three decisions I am least confident about
1. **Gates are MISCONFIGURED for .NET.** `.factory/gates.conf` notes `gates.sh` has no dotnet
   block, so any `full` run is MISCONFIGURED (fail-closed) and `test` is not in
   REQUIRED_FULL. Those files are protected policy; a human must add the dotnet block and add
   `test` to the required gates before slice 1 can go green. I cannot do this unattended.
2. **Test project in slice 0 is load-bearing** (`*.csproj`, `*.slnx`): forces `deep` gates, a
   human read, and it also needs `audit architecture` gates to be runnable. A single controller
   test is thin evidence; the real value is establishing the project.
3. **Controller unit test is weak.** It only asserts `View()` is returned. Whether the nav link
   renders needs an integration test + a new package dependency (an architectural/dependency
   decision reserved for humans). Accepting weak coverage vs. adding that dependency is your call.
