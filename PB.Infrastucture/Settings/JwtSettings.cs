namespace PB.Infrastucture.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public int ExpireMinutes { get; set; }
    }
}