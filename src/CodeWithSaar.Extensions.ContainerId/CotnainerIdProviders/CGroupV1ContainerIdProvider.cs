using Microsoft.Extensions.Logging;

namespace CodeWithSaar.Extensions.ContainerId;

internal class CGroupV1ContainerIdProvider : FileContainerIdProviderBase
{
    private const string InfoFilePath = "/proc/self/cgroup";
    public CGroupV1ContainerIdProvider(
        IContainerIdParser<CGroupV1ContainerIdProvider> matcher,
        ILogger<CGroupV1ContainerIdProvider>? logger = null)
        : base(InfoFilePath, matcher, logger)
    {
    }

}