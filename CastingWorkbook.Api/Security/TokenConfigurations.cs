namespace CastingWorkbook.Api.Security
{
    public class TokenConfigurations
    {
        public string? Audience { get; set; }
        public string? Issuer { get; set; }
        public string? SecretJwtKey { get; set; }
    }
}
