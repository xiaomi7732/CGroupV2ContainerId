using CodeWithSaar.Extensions.ContainerId;

string containerId = await ContainerService.GetContainerIdAsync();

if (string.IsNullOrEmpty(containerId))
{
    Console.Error.WriteLine("No container id found. Is this inside a container?");
    return -1;
}

Console.WriteLine("Container Id: {0}", containerId);
return 0;