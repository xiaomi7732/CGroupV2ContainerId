using System;
using System.Text.RegularExpressions;

namespace CodeWithSaar.Extensions.ContainerId;

internal class CGroupV2ContainerIdMatcher : IContainerIdMatcher<CGroupV2ContainerIdProvider>
{
    private const string Pattern = @"\/docker\/containers\/(.*?)\/";
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