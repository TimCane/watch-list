namespace WatchList.Core.Models
{
    public class AppSettings
    {
        public string JwtSecret { get; set; } = string.Empty;
        public string JwtIssuer { get; set; } = string.Empty;
        public string JwtAudience { get; set; } = string.Empty;
    }
}