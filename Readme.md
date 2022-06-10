# Get the container id

[![Package-Badge](https://img.shields.io/nuget/v/CodeWithSaar.Extensions.ContainerId?style=flat-square)](https://www.nuget.org/packages/CodeWithSaar.Extensions.ContainerId/)
[![Download-Badge](https://img.shields.io/nuget/dt/CodeWithSaar.Extensions.ContainerId?style=flat-square)](https://www.nuget.org/packages/CodeWithSaar.Extensions.ContainerId/)

Getting container id is important for logging. Let's get it.

## Get Started

* Add NuGet package

```shell
dotnet add package CodeWithSaar.Extensions.ContainerId --prerelease
```

* Put container id in your telemetry

```csharp
// Get container id.
string containerId = await ContainerService.GetContainerIdAsync();
// Log it.
_logger.LogInformation("This is some information from container: {containerId}", containerId);
```

* Output:

```shell
info: TestClass[0] This is some information from container: 01d1ad1a7b528295f2d03619b35f995be9ddddcfd2a83c013df129aa6cc4d332
```

That's it. Start this repo if you like it.

Alternatively, dependency injection is also supported, refer to [Use it with dependency injection](./docs/DI.md).

## Examples

* [Build a docker CLI that displays container id](./docs/CLI.md) - [source code](./src/CodeWithSaar.ContainerId.CLI/)
* [Use it in a worker](./src/CodeWithSaar.ContainerId.Worker/)
