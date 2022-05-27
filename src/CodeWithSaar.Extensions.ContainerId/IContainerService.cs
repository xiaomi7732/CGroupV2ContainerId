using System.Threading.Tasks;

namespace CodeWithSaar.Extensions.ContainerId;

public interface IContainerService
{
    /// <summary>
    /// Gets the container id. Returns string.Empty when not found.
    /// </summary>
    Task<string> GetContainerIdAsync();
}

internal interface IInternalContainerService : IContainerService
{

}