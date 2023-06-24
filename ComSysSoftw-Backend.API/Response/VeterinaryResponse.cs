namespace ComSysSoftw_Backend.API.Response
{
    public class VeterinaryResponse
    {
        public int Id { get; set; }
        public string name { get; set; }

        public string district { get; set; }
        public int UserId { get; set; }

        public string phone_number { get; set; }
        public string ImgUrl { get; set; }
    }
}
