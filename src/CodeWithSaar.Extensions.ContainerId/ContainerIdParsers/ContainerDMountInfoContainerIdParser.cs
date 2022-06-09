using System;
using System.Text.RegularExpressions;

namespace CodeWithSaar.Extensions.ContainerId;

internal class ContainerDMountInfoContainerIdParser : IContainerIdParser<ContainerDMountInfoContainerIdProvider>
{
    // An example of container id line:
    // 1735 1729 0:37 /kubepods/besteffort/pod3272f253-be44-4a82-a541-9083e68cf99f/a22b3a93bd510bf062765ec5df6608fa6cae186a476b0407bfb5369ff99afdd2 /sys/fs/cgroup/hugetlb ro,nosuid,nodev,noexec,relatime master:19 - cgroup cgroup rw,hugetlb
    // This is heuristic, the mount path is not always guaranteed. File issue at https://github.com/microsoft/ApplicationInsights-Kubernetes/issues if/when find it changed.
    private const string Pattern = @"/kubepods/.*?/.*?/(.*?)[\s|/]";
    private static readonly Regex s_ContainerIdMatchPattern = new Regex(Pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant, matchTimeout: TimeSpan.FromSeconds(1));

    public bool TryMatch(string input, out string result)
    {
        result = string.Empty;

        Match match = s_ContainerIdMatchPattern.Match(input);
        if (match.Success)
        {
            result = match.Groups[1].Value;
            return true;
        }
        return false;
    }
}