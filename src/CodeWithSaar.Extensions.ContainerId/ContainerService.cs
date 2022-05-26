using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeWithSaar.Extensions.ContainerId;

public static class ContainerService
{
    private static readonly Lazy<IEnumerable<IContainerService>> s_containerServices = new Lazy<IEnumerable<IContainerService>>(() =>
    {
        return new IContainerService[]{
            new CGroupV1ContainerIdProvider(new CGroupV1ContainerIdMatcher()),
            new CGroupV2ContainerIdProvider(new CGroupV2ContainerIdMatcher()),
        };
    }, isThreadSafe: true);

    private static IContainerService? _aggregatedService = null;

    public static Task<string> GetContainerIdAsync()
    {
        if (_aggregatedService is null)
        {
            _aggregatedService = new ContainerIdProvider(s_containerServices.Value);
        }

        return _aggregatedService.GetContainerIdAsync();
    }
}