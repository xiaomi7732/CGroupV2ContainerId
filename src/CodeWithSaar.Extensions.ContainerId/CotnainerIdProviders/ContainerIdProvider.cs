using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeWithSaar.Extensions.ContainerId;

public class ContainerIdProvider : IContainerService
{
    private readonly IEnumerable<IContainerService> _containerServices;

    public ContainerIdProvider(IEnumerable<IContainerService> containerServices)
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