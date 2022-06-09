using Microsoft.Extensions.Logging;

namespace CodeWithSaar.Extensions.ContainerId;

internal class ContainerDMountInfoContainerIdProvider : FileContainerIdProviderBase
{
    private const string InfoFilePath = "/proc/self/mountinfo";

    public ContainerDMountInfoContainerIdProvider(
        IContainerIdParser<ContainerDMountInfoContainerIdProvider> containerIdMatcher,
        ILogger<FileContainerIdProviderBase>? logger = null)
        : base(InfoFilePath, containerIdMatcher, logger)
    {
    }
}