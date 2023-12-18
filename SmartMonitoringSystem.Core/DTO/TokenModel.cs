namespace SmartMonitoringSystem.Core.DTO
{
    public class TokenModel
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public string? Email {  get; set; }
        public string? Password { get; set; }
        public int ID {  get; set; }
        public DateTime RefreshTokenExpirationDatatime { get; set; }

    }
}
