using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CodeWithSaar.Extensions.ContainerId;

internal class CGroupV2ContainerIdProvider : IContainerService
{
    private const string InfoFilePath = "/proc/self/mountinfo";
    private readonly IContainerIdMatcher _matcher;
    private readonly ILogger? _logger;


    public CGroupV2ContainerIdProvider(
        IContainerIdMatcher<CGroupV2ContainerIdProvider> matcher,
        ILogger<CGroupV1ContainerIdProvider>? logger = null)
    {
        _matcher = matcher ?? throw new ArgumentNullException(nameof(matcher));
        _logger = logger;
    }

    public async Task<string> GetContainerIdAsync()
    {
        if (!File.Exists(InfoFilePath))
        {
            _logger?.LogInformation("No info file by cgroup at {filePath}", InfoFilePath);
            return string.Empty;
        }

        using StreamReader reader = File.OpenText(InfoFilePath);
        while (!reader.EndOfStream)
        {
            string line = await reader.ReadLineAsync().ConfigureAwait(false);

            if (_matcher.TryMatch(line, out string result))
            {
                _logger?.LogInformation("Matched. Value: {containerId}", result);
                return result;
            }
        }
        _logger?.LogInformation("No container id matched.");
        return string.Empty;
    }
}