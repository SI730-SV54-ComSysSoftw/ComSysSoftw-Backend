namespace ComSysSoftw_Backend.API.Response
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public string text { get; set; }
        public string title { get; set; }
        public int UserId { get; set; }
        public int VeterinaryId { get; set; }
    }
}
