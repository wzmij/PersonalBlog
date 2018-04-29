namespace PB.Infrastucture.DTO
{
    public class JwtDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public long Expires { get; set; }
    }
}