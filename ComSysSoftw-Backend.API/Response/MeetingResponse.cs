namespace ComSysSoftw_Backend.API.Response
{
    public class MeetingResponse
    {
        public int Id { get; set; }
        public DateTime DateToMeet { get; set; }
        public int UserId { get; set; }
        public int VeterinaryId { get; set; }
    }
}
