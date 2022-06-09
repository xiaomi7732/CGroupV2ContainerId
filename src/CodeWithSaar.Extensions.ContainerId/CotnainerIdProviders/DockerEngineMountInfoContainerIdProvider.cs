using Microsoft.Extensions.Logging;

namespace CodeWithSaar.Extensions.ContainerId;

internal class DockerEngineMountInfoContainerIdProvider : FileContainerIdProviderBase
{
    private const string InfoFilePath = "/proc/self/mountinfo";

    public DockerEngineMountInfoContainerIdProvider(
        IContainerIdParser<DockerEngineMountInfoContainerIdProvider> matcher,
        ILogger<DockerEngineMountInfoContainerIdProvider>? logger = null)
        : base(InfoFilePath, matcher, logger)
    {
    }
}