# Get the container id

![Package-Badge](https://img.shields.io/nuget/v/CodeWithSaar.Extensions.ContainerId?style=flat-square)
![Download-Badge](https://img.shields.io/nuget/dt/CodeWithSaar.Extensions.ContainerId?style=flat-square)

Getting container id is important for diagnostic / logging.

## Get Started

* Add NuGet package

```shell
dotnet add package CodeWithSaar.Extensions.ContainerId --prerelease
```

* Put container id in your telemetry

```csharp
string containerId = await ContainerService.GetContainerIdAsync();
// Your logging shows container id now.
_logger.LogInformation("This is some information from container: {containerId}", containerId);
```

* Output:

```shell
info: TestClass[0] This is some information from container: 01d1ad1a7b528295f2d03619b35f995be9ddddcfd2a83c013df129aa6cc4d332
```


That's it.

Alternatively, dependency injection is also supported, refer to [Use it with dependency injection](#Use-it-with-dependency-injection).

## Example utilities

By using the library, it is easy to build some utilities.

* Public docker image to detect container id:

```shell
docker pull saars/cid
docker run saars/cid
```

Output:

> Container Id: 7f1477ac7aa29f3e52d8d4f25632e9df461a3855cc8cd8ad071ad94181381215

* Inspect logs from the worker in Kubernetes Cluster:

  * Deploy `saars/cid-worker` into a Kubernetes cluster.
  * Check the logs of the pod: `kubectl logs <podName>`

    ```shell
    info: CodeWithSaar.Extensions.ContainerId.CGroupV1ContainerIdProvider[0] No container id matched.
    info: CodeWithSaar.Extensions.ContainerId.CGroupV2ContainerIdProvider[0] Matched. Value: 01d1ad1a7b528295f2d03619b35f995be9ddddcfd2a83c013df129aa6cc4d332
    info: CodeWithSaar.ContainerId.Worker.Worker[0] Container Id: 01d1ad1a7b528295f2d03619b35f995be9ddddcfd2a83c013df129aa6cc4d332. Wait for 10 seconds.
    ```

    * Notice, in that case, the first provider missed the container since it doesn't exist. But the second provider got it.


## Use it with dependency injection

You still need to add the NuGet package, follow the instructions above. Then:

1. Register the services:

      ```csharp
      // TryAddContainerIdServices is an extension method provided in CodeWithSaar.Extensions.ContainerId.
      services.TryAddContainerIdServices();
      ```
1. Inject it and use the service:

      ```csharp
      private readonly IContainerService _containerService;
      class Consumer(IContainerService containerService)
      {
          _containerService = containerService ?? throw new ArgumentNullException(nameof(containerService));
      }

      public Task ShowContainerIdAsync()
      {
          Console.WriteLine(await _containerService.GetContainerIdAsync());
      }
      ```

## Implementation details

It has been working by fetching `/proc/self/cgroup` for container id until lately, `cGroupV2` rolls out, and there needs to be new ways to get it.

This repo is a yield of the investigations to aggregate various ways to get container ids for both cGroupV1 or cGroupV2 containers. When needed, it shall be able to be extended to support other technologies as time goes by.