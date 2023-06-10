namespace DefaultNamespace;

public interface ICommentDomain
{
    Task<string> Comment(Comments comment);
}