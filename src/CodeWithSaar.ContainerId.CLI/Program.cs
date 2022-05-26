using CodeWithSaar.Extensions.ContainerId;

string containerId = await ContainerService.GetContainerIdAsync();

if (string.IsNullOrEmpty(containerId))
{
    Console.WriteLine("No container id found. Is this inside a container?");
}