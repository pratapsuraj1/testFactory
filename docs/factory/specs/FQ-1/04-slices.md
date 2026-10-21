# FQ-1 Gate 4 - Slices: About page

The feature is ~15 lines of product code. Splitting further would produce slices smaller than
their own overhead, so there is one tracer slice plus one human prerequisite.

## Prerequisite (human, not a queue item)
Add dotnet support to `.claude/scripts/gates.sh` and add `test` to `REQUIRED_FULL`/`REQUIRED_DEEP`
in `.factory/gates.conf`. Protected policy; agents may not edit. Until done, gates are MISCONFIGURED.

## Slice 0 - About page, end to end (tracer bullet)
- Issue: #1 (reuse; relabel after approval)
- Scope: `About` action, `Views/Home/About.cshtml` (approved placeholder text), nav link in
  `_Layout.cshtml`, new `WebApplication1.Tests` xUnit project added to `WebApplication1.slnx`,
  one controller test.
- done_when: `GET /Home/About` renders a page titled "About" with the approved paragraph, the
  nav shows an "About" link to it, `dotnet build` and `dotnet test` pass, and the new test fails
  when the `About` action is removed.
- files_expected: WebApplication1/Controllers/HomeController.cs, WebApplication1/Views/Home/About.cshtml,
  WebApplication1/Views/Shared/_Layout.cshtml, WebApplication1.slnx,
  WebApplication1.Tests/WebApplication1.Tests.csproj, WebApplication1.Tests/HomeControllerTests.cs
- load_bearing: true (`*.csproj`, `*.slnx`)
- gate_level: deep
- confidence: medium
- label: `factory:wait-to-implement` (blocked on the gates prerequisite above); change to
  `factory:ready-to-implement` once a human completes it. Draft PR requires a human read.
