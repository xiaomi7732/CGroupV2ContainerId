using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeWithSaar.Extensions.ContainerId;

internal class ContainerIdProvider : IContainerService
{
    private readonly IEnumerable<IInternalContainerService> _containerServices;

    public ContainerIdProvider(IEnumerable<IInternalContainerService> containerServices)
    {
        _containerServices = containerServices ?? throw new System.ArgumentNullException(nameof(containerServices));
    }

    public async Task<string> GetContainerIdAsync()
    {
        foreach (IContainerService containerService in _containerServices)
        {
            string containerId = await containerService.GetContainerIdAsync().ConfigureAwait(false);
            if (containerId != string.Empty)
            {
                return containerId;
            }
        }
        return string.Empty;
    }
}