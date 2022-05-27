using System.ComponentModel;
using CodeWithSaar.Extensions.ContainerId;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

[Browsable(false)]
public static class Register
{
    public static IServiceCollection TryAddContainerIdServices(this IServiceCollection services)
    {
        services.TryAddTransient<IContainerIdMatcher<CGroupV1ContainerIdProvider>, CGroupV1ContainerIdMatcher>();
        services.TryAddTransient<IContainerIdMatcher<CGroupV2ContainerIdProvider>, CGroupV2ContainerIdMatcher>();

        services.TryAddEnumerable(ServiceDescriptor.Transient<IInternalContainerService, CGroupV1ContainerIdProvider>());
        services.TryAddEnumerable(ServiceDescriptor.Transient<IInternalContainerService, CGroupV2ContainerIdProvider>());

        services.TryAddTransient<IContainerService, ContainerIdProvider>();

        return services;
    }
}