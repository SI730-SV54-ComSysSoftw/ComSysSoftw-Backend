namespace DefaultNamespace;

public class CommentInfraestructure
{
    private readonly VetDBContext _vetDbContext;

    public CommentInfraestructure(VetDbContext context)
    {
        _VetDBContext = context;
    }
    
    public async Tack(string) Comment(Comments comment)
    {
        try
        {
            _VetDBContext.Comments.add(comment);
            await _VetDBContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}