namespace CodeWithSaar.Extensions.ContainerId;

public interface IContainerIdParser
{
    bool TryMatch(string input, out string result);
}

internal interface IContainerIdParser<T> : IContainerIdParser
    where T: IInternalContainerService
{

}