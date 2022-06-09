using System.ComponentModel;
using CodeWithSaar.Extensions.ContainerId;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

[Browsable(false)]
public static class Register
{
    public static IServiceCollection TryAddContainerIdServices(this IServiceCollection services)
    {
        services.TryAddTransient<IContainerIdParser<CGroupV1ContainerIdProvider>, CGroupV1ContainerIdParser>();
        services.TryAddTransient<IContainerIdParser<ContainerDMountInfoContainerIdProvider>, ContainerDMountInfoContainerIdParser>();
        services.TryAddTransient<IContainerIdParser<DockerEngineMountInfoContainerIdProvider>, DockerEngineMountInfoContainerIdParser>();

        services.TryAddEnumerable(ServiceDescriptor.Transient<IInternalContainerService, CGroupV1ContainerIdProvider>());
        services.TryAddEnumerable(ServiceDescriptor.Transient<IInternalContainerService, ContainerDMountInfoContainerIdProvider>());
        services.TryAddEnumerable(ServiceDescriptor.Transient<IInternalContainerService, DockerEngineMountInfoContainerIdProvider>());

        services.TryAddTransient<IContainerService, ContainerIdProvider>();

        return services;
    }
}