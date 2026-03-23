namespace ExampleThaiBevApp.Dtos
{
    public class JwtSettingDto
    {
        public string Secret { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public string ExpireInHours { get; set; } = null!;
    }
}
