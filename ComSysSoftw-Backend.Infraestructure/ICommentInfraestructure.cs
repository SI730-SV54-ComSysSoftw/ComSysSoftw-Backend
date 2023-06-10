namespace DefaultNamespace;

public interface ICommentInfraestructure
{
    Task<string> Comment(Comments comment);
}