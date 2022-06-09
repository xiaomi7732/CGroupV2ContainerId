using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CodeWithSaar.Extensions.ContainerId;

internal abstract class FileContainerIdProviderBase : IInternalContainerService
{
    private readonly ILogger? _logger;
    private readonly string _infoFilePath;
    private readonly IContainerIdParser _containerIdMatcher;

    public FileContainerIdProviderBase(
        string infoFilePath,
        IContainerIdParser containerIdMatcher,
        ILogger<FileContainerIdProviderBase>? logger)
    {
        _logger = logger;

        if (string.IsNullOrEmpty(infoFilePath))
        {
            throw new ArgumentException($"'{nameof(infoFilePath)}' cannot be null or empty.", nameof(infoFilePath));
        }
        _infoFilePath = infoFilePath;

        _containerIdMatcher = containerIdMatcher ?? throw new System.ArgumentNullException(nameof(containerIdMatcher));
    }

    public async Task<string> GetContainerIdAsync()
    {
        if (!File.Exists(_infoFilePath))
        {
            _logger?.LogInformation("No info file at {filePath}", _infoFilePath);
            return string.Empty;
        }

        using StreamReader reader = File.OpenText(_infoFilePath);
        while (!reader.EndOfStream)
        {
            string line = await reader.ReadLineAsync().ConfigureAwait(false);

            if (_containerIdMatcher.TryMatch(line, out string result))
            {
                _logger?.LogInformation("Matched. Value: {containerId}", result);
                return result;
            }
        }
        _logger?.LogInformation("No container id matched.");
        return string.Empty;
    }
}