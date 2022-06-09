using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeWithSaar.Extensions.ContainerId;

public static class ContainerService
{
    private static readonly Lazy<IEnumerable<IInternalContainerService>> s_containerServices = new Lazy<IEnumerable<IInternalContainerService>>(() =>
    {
        return new IInternalContainerService[]{
            new CGroupV1ContainerIdProvider(new CGroupV1ContainerIdParser()),
            new ContainerDMountInfoContainerIdProvider(new ContainerDMountInfoContainerIdParser()),
            new DockerEngineMountInfoContainerIdProvider(new DockerEngineMountInfoContainerIdParser()),
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