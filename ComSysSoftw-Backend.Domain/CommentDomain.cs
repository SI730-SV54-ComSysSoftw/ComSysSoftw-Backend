namespace DefaultNamespace;

public class CommentDomain : ICommentDomain
{
    private readonly ICommentInfraestructure _commentInfraestructure;

    public CommentDomain(ICommentInfraestructure commentInfraestructure)
    {
        _commentInfraestructure = commentInfraestructure;
    }

    public async Task<string> Comment(Comments comment)
    {
        return await _commentInfraestructure.Comment(comment);
    }

}