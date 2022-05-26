namespace CodeWithSaar.Extensions.ContainerId;

public interface IContainerIdMatcher
{
    bool TryMatch(string input, out string result);
}

public interface IContainerIdMatcher<T> : IContainerIdMatcher
{

}